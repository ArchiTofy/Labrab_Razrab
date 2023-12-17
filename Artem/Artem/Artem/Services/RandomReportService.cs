using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Artem.Models;

namespace Artem.Services
{
    public class RandomReportService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Random _random = new Random();

        public RandomReportService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var reportService = scope.ServiceProvider.GetRequiredService<IReportService>();

                    var randomReport = GenerateRandomReport();

                    reportService.CreateReport(randomReport);
                }

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }

        private Report GenerateRandomReport()
        {
            var randomReport = new Report
            {
                OperatorFullName = GenerateRandomFullName(),
                Detail = GenerateRandomDetail(),
                Operation = _random.Next(1, 10),
                OperationType = GenerateRandomOperationType(),
                LaborIntensityFact = _random.Next(1, 100),
                Quantity = _random.Next(1, 1000)
            };

            return randomReport;
        }

        private string GenerateRandomFullName()
        {
            var firstNames = new string[] { "Иван", "Петр", "Мария", "Елена" };
            var lastNames = new string[] { "Иванов", "Петров", "Сидорова", "Павлова" };
            var middleNames = new string[] { "Иванович", "Петрович", "Сергеевна", "Васильевна" };

            var fullName = $"{firstNames[_random.Next(firstNames.Length)]} {lastNames[_random.Next(lastNames.Length)]} {middleNames[_random.Next(middleNames.Length)]}";

            return fullName;
        }

        private string GenerateRandomDetail()
        {
            var details = new string[] { "Деталь1", "Деталь2", "Деталь3", "Деталь4" };

            return details[_random.Next(details.Length)];
        }

        private OperationType GenerateRandomOperationType()
        {
            var operationTypes = Enum.GetValues(typeof(OperationType));
            return (OperationType)operationTypes.GetValue(_random.Next(operationTypes.Length));
        }
    }
}
