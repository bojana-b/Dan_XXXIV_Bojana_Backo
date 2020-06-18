using System;
using System.Threading;

namespace Dan_XXXIV_Bojana_Backo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool repeat = false;
            uint numberOfClientsATM1 = 0;
            uint numberOfClientsATM2 = 0;
            BankAcct acct = new BankAcct(10000);
            do
            {
                Console.Write("\nEnter the NUMBER of clients for ATM_1 -> ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nYou must provide some input!");
                    repeat = true;
                }
                else if (!UInt32.TryParse(input, out numberOfClientsATM1))
                {
                    Console.WriteLine("\nRead instructions!!!!");
                    repeat = true;
                }
                else
                {
                    numberOfClientsATM1 = UInt32.Parse(input);
                    repeat = false;
                }
            } while (repeat);

            do
            {
                Console.Write("\nEnter the NUMBER of clients for ATM_2 -> ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nYou must provide some input!");
                    repeat = true;
                }
                else if (!UInt32.TryParse(input, out numberOfClientsATM2))
                {
                    Console.WriteLine("\nRead instructions!!!!");
                    repeat = true;
                }
                else
                {
                    numberOfClientsATM2 = UInt32.Parse(input);
                    repeat = false;
                }
            } while (repeat);

            Console.WriteLine();

            // Number of Threads is equal to number of clients in both ATM
            Thread[] threads = new Thread[numberOfClientsATM1 + numberOfClientsATM2];

            // Create Threads for clients for ATM1
            for (uint i = 0; i < numberOfClientsATM1; i++)
            {
                Thread t = new Thread(() => acct.WithdrawMachineOne(random.Next(100, 10001)));
                threads[i] = t;
                threads[i].Name = string.Format("Client_{0}_ATM1", i + 1);
            }
            // Create Threads for clients for ATM2
            for (uint i = numberOfClientsATM1; i < numberOfClientsATM2 + numberOfClientsATM1; i++)
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
