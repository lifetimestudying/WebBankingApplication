using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using WebBankingApp.Models;

namespace WebBankingApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<BankContext>();

            // Look for customers.
            if (context.Customer.Any())
                return; // DB has already been seeded.

            const string initialDeposit = "Initial deposit";
            const string format = "dd/MM/yyyy hh:mm:ss tt";

            context.Customer.AddRange(
                new Customer
                {
                    CustomerID = 2100,
                    CustomerName = "Matthew Bolger",
                    Address = "123 Fake Street",
                    City = "Melbourne",
                    PostCode = "3000",
                    Phone = "+61 1234 1234",
                    CustomerStatus = Status.Activate
                },
                new Customer
                {
                    CustomerID = 2200,
                    CustomerName = "Rodney Cocker",
                    Address = "456 Real Road",
                    City = "Melbourne",
                    PostCode = "3005",
                    Phone = "+61 0000 1234",
                    CustomerStatus = Status.Activate
                },
                new Customer
                {
                    CustomerID = 2300,
                    CustomerName = "Shekhar Kalra",
                    Phone = "+61 0000 3212",
                    CustomerStatus = Status.Activate
                }, new Customer
                {
                    CustomerID = 0000,
                    CustomerName = "New User",
                    Phone = "+61 0000 3212",
                    CustomerStatus = Status.Activate
                });

            context.Login.AddRange(
                new Login
                {
                    LoginID = "12345678",
                    CustomerID = 2100,
                    PasswordHash = "YBNbEL4Lk8yMEWxiKkGBeoILHTU7WZ9n8jJSy8TNx0DAzNEFVsIVNRktiQV+I8d2",
                    ModifyDate = DateTime.ParseExact("09/06/2020 08:00:00 PM", format, null)
                },
                new Login
                {
                    LoginID = "38074569",
                    CustomerID = 2200,
                    PasswordHash = "EehwB3qMkWImf/fQPlhcka6pBMZBLlPWyiDW6NLkAh4ZFu2KNDQKONxElNsg7V04",
                    ModifyDate = DateTime.ParseExact("07/06/2020 08:00:00 PM", format, null)
                },
                new Login
                {
                    LoginID = "17963428",
                    CustomerID = 2300,
                    PasswordHash = "LuiVJWbY4A3y1SilhMU5P00K54cGEvClx5Y+xWHq7VpyIUe5fe7m+WeI0iwid7GE",
                    ModifyDate = DateTime.ParseExact("08/06/2020 08:00:00 PM", format, null)
                });

            context.Account.AddRange(
                new Account
                {
                    AccountNumber = 4100,
                    AccountType = AccountType.Saving,
                    CustomerID = 2100,
                    ModifyDate = DateTime.UtcNow,
                    Balance = 500,
                    AccountStatus = Status.Activate
                },
                new Account
                {
                    AccountNumber = 4101,
                    AccountType = AccountType.Checking,
                    CustomerID = 2100,
                    ModifyDate = DateTime.UtcNow,
                    Balance = 500,
                    AccountStatus = Status.Activate
                },
                new Account
                {
                    AccountNumber = 4200,
                    AccountType = AccountType.Saving,
                    CustomerID = 2200,
                    ModifyDate = DateTime.UtcNow,
                    Balance = 500.95m,
                    AccountStatus = Status.Activate
                },
                new Account
                {
                    AccountNumber = 4300,
                    AccountType = AccountType.Checking,
                    CustomerID = 2300,
                    ModifyDate = DateTime.UtcNow,
                    Balance = 1250.50m,
                    AccountStatus = Status.Activate
                });

            context.Transaction.AddRange(
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = initialDeposit,
                    TransactionTimeUtc = DateTime.ParseExact("08/06/2020 08:00:00 PM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = initialDeposit,
                    TransactionTimeUtc = DateTime.ParseExact("09/06/2020 09:00:00 AM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = initialDeposit,
                    TransactionTimeUtc = DateTime.ParseExact("09/06/2020 01:00:00 PM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = initialDeposit,
                    TransactionTimeUtc = DateTime.ParseExact("09/06/2020 03:00:00 PM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = initialDeposit,
                    TransactionTimeUtc = DateTime.ParseExact("10/06/2020 11:00:00 AM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4101,
                    Amount = 500,
                    Comment = initialDeposit,
                    TransactionTimeUtc = DateTime.ParseExact("08/06/2020 08:30:00 PM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4200,
                    Amount = 500,
                    Comment = initialDeposit,
                    TransactionTimeUtc = DateTime.ParseExact("08/06/2020 09:00:00 PM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4200,
                    Amount = 0.95m,
                    Comment = initialDeposit,
                    TransactionTimeUtc = DateTime.ParseExact("08/06/2020 09:00:00 PM", format, null)
                },
                new Transaction
                {
                    TransactionType = TransactionType.Deposit,
                    AccountNumber = 4300,
                    Amount = 1250.50m,
                    Comment = initialDeposit,
                    TransactionTimeUtc = DateTime.ParseExact("08/06/2020 10:00:00 PM", format, null)
                });

            context.Payee.AddRange(
                new Payee
                {
                    PayeeName = "Telstra",
                    Address = "13 Telstra Street",
                    City = "Telstra city",
                    State = State.NSW,
                    PostCode = "9999",
                    Phone = "+61 7777 6666"
                },
                new Payee
                {
                    PayeeName = "RMIT",
                    Address = "13 RMIT Street",
                    City = "RMIT city",
                    State = State.VIC,
                    PostCode = "3000",
                    Phone = "+61 1234 1234"
                },
                new Payee
                {
                    PayeeName = "Tesla",
                    Address = "13 Tesla Street",
                    City = "Tesla city",
                    State = State.SA,
                    PostCode = "5000",
                    Phone = "+61 9845 9456"
                },
                new Payee
                {
                    PayeeName = "Eletricity",
                    Phone = "+61 9888 9888"
                });

            //context.BillPay.Add(
            //    new BillPay
            //    {
            //        AccountNumber = 4100,
            //        PayeeID = 2,
            //        Amount = (decimal) 40.00,
            //        SchedualDate = DateTime.ParseExact("26/01/2021 01:47:00 AM", format, null),
            //        Period = Period.OnceOff,
            //        ModifyDate = DateTime.ParseExact("20/01/2021 11:20:00 AM", format, null)
            //    });

            context.SaveChanges();
        }
    }
}
