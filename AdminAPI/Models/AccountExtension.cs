using System;

namespace AdminAPI.Models
{
    public static class AccountExtension
    {
        public static void Deposit(this Account account, decimal amount)
        {
            account.Balance += amount;
            account.Transactions.Add(new Transaction
            {
                TransactionType = TransactionType.Deposit,
                Amount = amount,
                TransactionTimeUtc = DateTime.UtcNow
            });
        }

        public static bool EnoughBalance(this Account account, decimal amount)
        {
            if (account.AccountType == AccountType.Checking)
            {
                if (account.Balance - amount < 200)
                {
                    return false;
                }
            }

            if (account.Balance - amount < 0)
            {
                return false;
            }

            return true;
        }

        public static void Withdraw(this Account account, decimal amount)
        {
            account.Balance -= amount;
            account.Transactions.Add(new Transaction
            {
                TransactionType = TransactionType.Withdraw,
                Amount = amount,
                TransactionTimeUtc = DateTime.UtcNow
            });
        }

        public static void Tranfer(this Account accountFrom, Account accountTo, decimal amount, string comment)
        {
            accountFrom.Balance -= amount;
            accountTo.Balance += amount;
            accountFrom.Transactions.Add(new Transaction
            {
                TransactionType = TransactionType.Transfer,
                DestAccountNumber = accountTo.AccountNumber,
                Amount = amount,
                Comment = comment,
                TransactionTimeUtc = DateTime.UtcNow
            });
        }

        public static void ChargeWithdrawServiceFee(this Account account)
        {
            account.Balance -= (decimal)0.10;
            account.Transactions.Add(new Transaction
            {
                TransactionType = TransactionType.ServiceFee,
                Amount = (decimal)0.10,
                TransactionTimeUtc = DateTime.UtcNow
            });
        }

        public static void ChargeTransferServiceFee(this Account account)
        {
            account.Balance -= (decimal)0.20;
            account.Transactions.Add(new Transaction
            {
                TransactionType = TransactionType.ServiceFee,
                Amount = (decimal)0.20,
                TransactionTimeUtc = DateTime.UtcNow
            });
        }

        public static void AddBillPay(this Account account, int payeeID, decimal amount, DateTime schedualDate, Period period) 
        {
            account.BillPays.Add(new BillPay
            {
                AccountNumber = account.AccountNumber,
                PayeeID = payeeID,
                Amount = amount,
                SchedualDate = schedualDate,
                Period = period,
                ModifyDate = DateTime.UtcNow
            });
        } 

        public static void ProcessBillPay(this Account account, BillPay billpay)
        {
            // decrease balance by bill payment amount
            account.Balance -= billpay.Amount;

            // add bill payment transactions
            account.Transactions.Add(new Transaction
            {
                TransactionType = TransactionType.BillPay,
                Amount = billpay.Amount,
                Comment = "Bill payment to Payee " + billpay.PayeeID,
                TransactionTimeUtc = DateTime.UtcNow
            });

            // renew schedual date based on period been set
            if (billpay.Period == Period.OnceOff)
            {
                account.BillPays.Remove(billpay);
            }            
            else if (billpay.Period == Period.Weekly)
            {
                billpay.SchedualDate = billpay.SchedualDate.AddDays(7);
            }            
            else if (billpay.Period == Period.Monthly)
            {
                billpay.SchedualDate = billpay.SchedualDate.AddMonths(1);
            }            
            else if (billpay.Period == Period.Quarterly)
            {
                billpay.SchedualDate = billpay.SchedualDate.AddMonths(3);
            }            
            else if (billpay.Period == Period.Annually)
            {
                billpay.SchedualDate = billpay.SchedualDate.AddYears(1);
            }
        }
    }
}
