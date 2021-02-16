using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using WebBankingApp.Data;
using WebBankingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Collections.Generic;

namespace WebBankingApp.BackgroundServices
{
    public class AutoEmailBackGroundService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<AutoEmailBackGroundService> _logger;

        public AutoEmailBackGroundService(IServiceProvider services, ILogger<AutoEmailBackGroundService> logger)
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Auto Email Background Service is running.");

            using var scope = _services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BankContext>();
            var accounts = await context.Account.ToListAsync(stoppingToken);

            IDictionary<int, int> previousTransactionDict = new Dictionary<int, int>();
            IDictionary<int, decimal> previousBalanceDict = new Dictionary<int, decimal>();

            foreach (var account in accounts)
            {
                previousTransactionDict.Add(account.AccountNumber, account.Transactions.Count);
                previousBalanceDict.Add(account.AccountNumber, account.Balance);
            }


            while (!stoppingToken.IsCancellationRequested)
            {
                await DoWork(stoppingToken, previousTransactionDict, previousBalanceDict);

                _logger.LogInformation("Auto Email Background Service is waiting 3 minutes.");

                await Task.Delay(TimeSpan.FromMinutes(3), stoppingToken);
            }
        }

        private async Task DoWork(CancellationToken cancellationToken, IDictionary<int, int> previousTransactionDict, IDictionary<int, decimal> previousBalanceDict)
        {
            _logger.LogInformation("Auto Email Background Service is scanning for account changes.");

            using var scope = _services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BankContext>();
            var customers = await context.Customer.ToListAsync(cancellationToken);
            var accounts = await context.Account.ToListAsync(cancellationToken);

            decimal diffBalance = 0;
            int diffTransactionCount = 0;

            List<Transaction> tempTransaction = new List<Transaction>();

            try
            {
                // check if new activity detected
                foreach (var account in accounts)
                {

                    if (previousTransactionDict[account.AccountNumber] < account.Transactions.Count
                        || previousBalanceDict[account.AccountNumber] != account.Balance)
                    {
                        diffBalance = AccountExtension.GetDiffBalance(previousBalanceDict[account.AccountNumber], account.Balance);
                        diffTransactionCount = AccountExtension.GetDiffTransactions(account.Transactions.Count, previousTransactionDict[account.AccountNumber]);

                        tempTransaction.AddRange(account.Transactions);

                        // set range to be removed from list to keep new activites only
                        var removeRange = account.Transactions.Count - diffTransactionCount;

                        tempTransaction.Reverse();

                        tempTransaction.RemoveRange(diffTransactionCount, removeRange);

                        SendEmail(account.AccountNumber, account.Balance, diffBalance, tempTransaction);

                        // update dict as previous to be used to compare with new values
                        previousTransactionDict[account.AccountNumber] = account.Transactions.Count;
                        previousBalanceDict[account.AccountNumber] = account.Balance;
                        tempTransaction.Clear();
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
             
            _logger.LogInformation("Auto Email Background Service processing completed.");
        }
  

        private static void SendEmail(int accountNumber, decimal currentBalance, decimal diffBalance, List<Transaction> transactions)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("test@test.com");
            mailMessage.To.Add(new MailAddress("s3743318@student.rmit.edu.au"));
            mailMessage.Subject = "MCBA Account Status";
            mailMessage.Body = EmailBody(accountNumber, currentBalance, diffBalance, transactions);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "adamwdtproject@gmail.com",
                Password = "@Power123"
            };
            
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        private static string EmailBody(int accountNumber, decimal currentBalance, decimal diffBalance, List<Transaction> transactions)
        {   
            string bodyTop = $" ---- New Activities for Account - {accountNumber}  ----\n\n" +
                                $"Current Account Balance: ${currentBalance:0.00}\n\n" +
                                $"Balance Differences: ${diffBalance:0.00}\n\n";

            var bodyBottom = string.Empty;
            
            foreach(var transaction in transactions)
            {
                bodyBottom += $" ---- Transaction ID - {transaction.TransactionID}  ----\n" +
                                $"Transaction Type: {transaction.TransactionType}\n" +
                                $"Account From: {transaction.AccountNumber}\n" +
                                $"Account To: {transaction.DestAccountNumber}\n" +
                                $"Amount: ${transaction.Amount:0.00}\n" +
                                $"Comment: {transaction.Comment}\n" +
                                $"Transaction Date: {TimeZoneInfo.ConvertTimeFromUtc(transaction.TransactionTimeUtc.Value, TimeZoneInfo.Local).ToString("dd/MM/yyyy hh:mm:ss tt")}\n\n";
            }

            return bodyTop + bodyBottom;
        }

    }
}
