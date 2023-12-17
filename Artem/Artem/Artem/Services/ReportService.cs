// IReportService.cs
using Artem.Data.Repositories;
using Artem.Models;
namespace Artem.Services
{
    public interface IReportService
    {
        IEnumerable<Report> GetAllReports();
        Report GetReportById(int id);
        void CreateReport(Report report);
        void UpdateReport(Report report);
        void DeleteReport(int id);
        IEnumerable<Report> GetReportsByOperationType(OperationType operationType);

    }
}


namespace Artem.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public IEnumerable<Report> GetAllReports()
        {
            return _reportRepository.GetAllReports();
        }

        public Report GetReportById(int id)
        {
            return _reportRepository.GetReportById(id);
        }

        public void CreateReport(Report report)
        {
            _reportRepository.CreateReport(report);
        }

        public void UpdateReport(Report report)
        {
            _reportRepository.UpdateReport(report);
        }

        public void DeleteReport(int id)
        {
            _reportRepository.DeleteReport(id);
        }
        public IEnumerable<Report> GetReportsByOperationType(OperationType operationType)
        {
            // Реализация для фильтрации по типу операции
            return _reportRepository.GetReportsByOperationType(operationType);
        }
    }
}
