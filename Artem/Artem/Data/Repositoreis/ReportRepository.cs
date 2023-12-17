// IReportRepository.cs
using Artem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Artem.Data.Repositories
{
    public interface IReportRepository
    {
        IEnumerable<Report> GetAllReports();
        Report GetReportById(int id);
        void CreateReport(Report report);
        void UpdateReport(Report report);
        void DeleteReport(int id);
        IEnumerable<Report> GetReportsByOperationType(OperationType operationType);

    }
}

namespace Artem.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ArtemDbContext _context;

        public ReportRepository(ArtemDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Report> GetAllReports()
        {
            return _context.Reports.ToList();
        }

        public Report GetReportById(int id)
        {
            return _context.Reports.Find(id);
        }

        public void CreateReport(Report report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
        }

        public void UpdateReport(Report report)
        {
            _context.Reports.Update(report);
            _context.SaveChanges();
        }

        public void DeleteReport(int id)
        {
            var report = _context.Reports.Find(id);
            if (report != null)
            {
                _context.Reports.Remove(report);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Report> GetReportsByOperationType(OperationType operationType)
        {
            return _context.Reports.Where(r => r.OperationType == operationType).ToList();
        }
    }
}
