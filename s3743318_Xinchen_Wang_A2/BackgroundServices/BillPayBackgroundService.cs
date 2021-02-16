using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using WebBankingApp.Data;
using WebBankingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebBankingApp.BackgroundServices
{
    public class BillPayBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<BillPayBackgroundService> _logger;

        public BillPayBackgroundService(IServiceProvider services, ILogger<BillPayBackgroundService> logger)
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Billpay Background Service is running.");

            while (!stoppingToken.IsCancellationRequested)
            {
                await DoWork(stoppingToken);

                _logger.LogInformation("Billpay Background Service is waiting a minute.");

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private async Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Billpay Background Service is processing bills.");

            using var scope = _services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BankContext>();
            var accounts = await context.Account.ToListAsync(cancellationToken);
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);

            foreach(var account in accounts)
            {
                foreach(var bill in account.BillPays)
                {
                    // check if schedualed date occured and process the payment
                    if (localTime >= bill.SchedualDate.ToLocalTime() && account.EnoughBalance(bill.Amount) 
                        && bill.BillPayStatus == Status.Activate && account.AccountStatus == Status.Activate)
                    {
                        account.ProcessBillPay(bill);
                    }
                }
            }

            await context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Billpay Background Service processing completed.");
        }
        
    }
}
