using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAppLayerArchetec.Model
{
    class Account
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
        public string OpeningDate { get; set; }
        public double balance = 0;
        public double Deposit(double amount)
        {
            balance += amount;
            return balance;
        }
        public double Withdraw(double amount)
        {
            balance-= amount;
            return balance;
        }
    }
}
