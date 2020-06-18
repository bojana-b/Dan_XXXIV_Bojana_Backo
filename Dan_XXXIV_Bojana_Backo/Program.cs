using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dan_XXXIV_Bojana_Backo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numberOfClientsATM1 = 3;
            int numberOfClientsATM2 = 5;
            BankAcct acct = new BankAcct(10000);
            Thread[] threads = new Thread[numberOfClientsATM1 + numberOfClientsATM2];
            for (int i = 0; i < numberOfClientsATM1; i++)
            {
                Thread t = new Thread(() => acct.WithdrawMachineOne(random.Next(100, 10001)));
                threads[i] = t;
                threads[i].Name = string.Format("Client_{0}_ATM1", i + 1);
                
            }
            for (int i = numberOfClientsATM1; i < numberOfClientsATM2 + numberOfClientsATM1; i++)
            {
                Thread t = new Thread(() => acct.WithdrawMachineTwo(random.Next(100, 10001)));
                threads[i] = t;
                threads[i].Name = string.Format("Client_{0}_ATM2", i + 1);
            }
            foreach (var i in threads)
            {
                i.Start();
            }
            Console.ReadKey();
        }
    }
}
