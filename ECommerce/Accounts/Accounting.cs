using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegation;

namespace Accounts
{
    public class Accounting
    {
        public event Operation underBalance;  //we cannot declare the event without delegate
        public event Operation overBalance;
        public double Balance { get; set; }
        public Accounting(double initialAmount)
        {
            Balance = initialAmount;
        }
        public void Withdraw(double amount)
        {
            double result = Balance - amount;
            if (result < 10000)
            {
                //raise an event:underbalance
                underBalance(8);
                Console.WriteLine("");
            }
            Balance -= amount;
        }
        public void Deposit(double amount)
        {
            Balance += amount;
            if (Balance > 250000)
            {
                //raise an event :overbalance
                overBalance(10);

            }

        }
    }
}
