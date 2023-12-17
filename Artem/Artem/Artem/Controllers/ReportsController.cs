using Microsoft.AspNetCore.Mvc;
using Artem.Models;
using Artem.Services;
using System.Collections.Generic;

namespace Artem.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: Reports
        public IActionResult Index(OperationType? operationType)
        {
            IEnumerable<Report> filteredReports;

            if (operationType.HasValue)
            {
                // Выполните фильтрацию по operationType
                filteredReports = _reportService.GetReportsByOperationType(operationType.Value);
            }
            else
            {
                // Выполните другую логику, если operationType равен null
                filteredReports = _reportService.GetAllReports();
            }

            // Возвращайте отфильтрованные отчеты в представление
            return View(filteredReports);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OperatorFullName,Detail,Operation,OperationType,LaborIntensityFact,Quantity")] Report report)
        {
            if (ModelState.IsValid)
            {
                _reportService.CreateReport(report);
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        // GET: Reports/Edit/5
        public IActionResult Edit(int id)
        {
            Report report = _reportService.GetReportById(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Reports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,OperatorFullName,Detail,Operation,OperationType,LaborIntensityFact,Quantity")] Report report)
        {
            if (id != report.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _reportService.UpdateReport(report);
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        // GET: Reports/Delete/5
        public IActionResult Delete(int id)
        {
            _reportService.DeleteReport(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
