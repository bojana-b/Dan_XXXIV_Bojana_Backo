using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_XXXIV_Bojana_Backo
{
    class BankAcct
    {
        private Object acctLock = new object();
        double Balance { set; get; }
        Random random = new Random();

        public BankAcct(double bal)
        {
            Balance = bal;
        }
        public double Withdraw(double amt)
        {
            if((Balance - amt) < 0)
            {
                Console.WriteLine("Sorry {0} in Account", Balance);
                return Balance;
            }
            lock (acctLock)
            {
                if(Balance >= amt)
                {
                    Console.WriteLine("Removed {0} and {1} left in Account", amt, (Balance - amt));
                    Balance -= amt;
                }
                return Balance;
            }
        }
        public void DoTransactions(int persons)
        {
            for (int i = 0; i < persons; i++)
            {
                Withdraw(random.Next(100, 10001));
            }
        }
    }
}
