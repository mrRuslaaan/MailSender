using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace HW6
{
    class Program
    {
        public static int N = 10;
        public static int[,] mas1 = new int[N, N];
        public static int[,] mas2 = new int[N, N];

        static void Main(string[] args)
        {
            #region Task1
            ////Parallel.Invoke(MasCreate(out mas1), MasCreate(out mas2)); как преобразовать метод MasCreate так, чтобы его можно было передать в Parellel.Invoke    
            //Parallel.Invoke(() => 
            //{
            //    Console.WriteLine(DateTime.Now);
            //    Random rand = new Random();
            //    mas1 = new int[N, N];
            //    int k;
            //    for (int i = 0; i < N; i++)
            //        for (int j = 0; j < N; j++)
            //        {
            //            k = rand.Next(0, 10);
            //            mas1[i, j] = k;
            //        }
            //},
            //()=> 
            //{
            //    Console.WriteLine(DateTime.Now);
            //    Random rand = new Random();
            //    mas2 = new int[N, N];
            //    int k;
            //    for (int i = 0; i < N; i++)
            //        for (int j = 0; j < N; j++)
            //        {
            //            k = rand.Next(0, 10);
            //            mas2[i, j] = k;
            //        }
            //});
            //MasMultiplyAsync(mas1, mas2);
            //Console.WriteLine("Основной поток продолжается");
            //Thread.Sleep(5000);
            #endregion

            #region Task2
            string targetDirectory = "C:\\Users\\annae\\Desktop\\Files";
            string[] fileNames = Directory.GetFiles(targetDirectory);

            foreach(string fileName in fileNames)
            {
                OpenFileForReadingAndCountAsync(fileName);
            }  






            #endregion
        }

        #region Task1
        static void Print(int[,] mas)
        {
            Console.WriteLine("\nМассив ");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < N; j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
            }
        }

        static void MasCreate(out int[,] mas)
        {
            Random rand = new Random();
            mas = new int[N, N];
            int k;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    k = rand.Next(0, 10);
                    mas[i, j] = k;
                }
        }

        static async Task MasCreateAsync(int[,] mas)
        {
            await Task.Run(() => MasCreate(out mas));
        }

        static void MasMultiply(ref int[,] mas1, ref int[,] mas2)
        {
            int[,] res = new int[N,N];
            Console.WriteLine("\nРезультат");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < N; j++)
                {
                    res[i, j] = mas1[i, j] * mas2[i, j];
                    Console.Write(res[i, j] + " ");
                }
            }
        }
        static async void MasMultiplyAsync(int[,] mas1, int[,] mas2)
        {
            await Task.Run(() => MasMultiply(ref mas1, ref mas2));
        }
        #endregion

        #region Task2

        static void OpenFileForReadingAndCount(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                double result = 0;
                double k_1 = 0;
                double k_2 = 0;
                int count = 0;
                string str = reader.ReadToEnd();

                string str_1 = "";
                for (int i = 2; i < str.Length; i++)
                {
                    while (str[i].ToString() != " ")
                    {
                        str_1 += str[i];
                        if (i < str.Length)
                            i++;
                        if (i == str.Length)
                            break;
                    }
                    count++;
                    if (count == 1)
                    {
                        k_1 = Convert.ToDouble(str_1);
                        str_1 = "";
                    }
                    if (count == 2)
                    {
                        k_2 = Convert.ToDouble(str_1);
                    }
                }
                if (str[0] == '1')
                {
                    result = k_1 * k_2;
                    Console.WriteLine("Умножение {0}", result);
                }
                else
                {
                    Console.WriteLine("Деление");
                }
                reader?.Close();

                WriteResultInFileAsync(result);
            }
        } 
        static void WriteResultInFile(double result)
        {
            using (StreamWriter writer = new StreamWriter("Result.txt", true))
            {
                writer.WriteLine(result);
                writer?.Close();
            }
        }

        static async void WriteResultInFileAsync(double result)
        {
            await Task.Run(() => WriteResultInFile(result));
        }
        static async void OpenFileForReadingAndCountAsync(string fileName)
        {
            await Task.Run(() => OpenFileForReadingAndCount(fileName));
        }
        #endregion
    }
}
