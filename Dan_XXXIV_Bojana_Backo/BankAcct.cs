using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dan_XXXIV_Bojana_Backo
{
    // Class BankAcct represent Bank Account
    // Two Withdraw functions, one for each ATM 
    class BankAcct
    {
        private Object acctLock = new object();
        double Balance { set; get; }

        public BankAcct(double bal)
        {
            Balance = bal;
        }
        public void WithdrawMachineOne(double amt)
        {
            if((Balance - amt) < 0)
            {
                Console.WriteLine("{0} is trying to withdraw {1} RSD", Thread.CurrentThread.Name, amt);
                Console.WriteLine("Sorry you are trying to withdraw {0} from ATM_1, but in Account is only {1}", amt, Balance);
            }
            // Lock the critical section of code
            lock (acctLock)
            {
                if(Balance >= amt)
                {
                    Console.WriteLine("{0} is trying to withdraw {1} RSD.", Thread.CurrentThread.Name, amt);
                    Console.WriteLine("Removed {0} from ATM_1 and {1} left in Account.", amt, (Balance - amt));
                    Balance -= amt;
                }
            }
        }
        public void WithdrawMachineTwo(double amt)
        {
            if ((Balance - amt) < 0)
            {
                Console.WriteLine("{0} is trying to withdraw {1} RSD.", Thread.CurrentThread.Name, amt);
                Console.WriteLine("Sorry you are trying to withdraw {0} from ATM_2, but in Account is only {1}.", amt, Balance);
            }
            // Lock the critical section of code
            lock (acctLock)
            {
                if (Balance >= amt)
                {
                    Console.WriteLine("{0} is trying to withdraw {1} RSD", Thread.CurrentThread.Name, amt);
                    Console.WriteLine("Removed {0} from ATM_2 and {1} left in Account", amt, (Balance - amt));
                    Balance -= amt;
                }
            }
        }
    }
}
