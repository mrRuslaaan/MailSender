using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n:");
            int n = Convert.ToInt32(Console.ReadLine());
            FactorialThreadClass fact = new FactorialThreadClass(n);
            SumThreadClass sum = new SumThreadClass(n);

            Thread FactrorialThread = new Thread(new ThreadStart(fact.Factorial2));
            FactrorialThread.Start();

            Thread SumThread = new Thread(new ThreadStart(sum.Sum));
            SumThread.Start();
        }

        public class SumThreadClass
        {
            private int _n;
            private int _sum = 0;
            public SumThreadClass(int n)
            {
                _n = n;
            }

            public void Sum()
            {
                for (int i = _n; i > 0; i--)
                {
                    _sum = _sum + i;
                }
                Console.WriteLine(_sum);
            }

        }

        public class FactorialThreadClass
        {
            private int _n;
            private int _fact = 1;
            public FactorialThreadClass(int n)
            {
                _n = n;
            }

            public void Factorial2()
            {
                for (int i = _n; i > 0; i--)
                {
                    _fact = _fact * i;
                }
                Console.WriteLine(_fact);
            }
            public int Factorial1(int n)
            {
                if (n == 0)
                    return 1;
                else
                    return n * Factorial1(n - 1);
            }
        }


    }
   
}
