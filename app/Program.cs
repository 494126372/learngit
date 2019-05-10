using System.IO;
using System.Net;
using System.Threading.Tasks;
using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            GetValue();
            int a = 12;
            string str = DownloadWebStr();
            System.Console.WriteLine($"Main is run { a}!" + str);
            Console.ReadKey();
        }
        static Task<double> Tas(double a, double b)
        {
            double d = 0;
            return Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    d = a + b;
                }

                return d;
            });
        }
        static Task TT()
        {
            return Task.Run(() =>
            {

                System.Console.WriteLine("Hello TT is Run....");
            });
        }
        public static async void GetValue()
        {
            // await 之后的所有代码都会在其执行完成后执行 OK 
            // await 异步任务 异步任务必须是以Task或者Task<TResult>作为返回值的
            double d = await Tas(100.0, 10.0);
            await TT();
            System.Console.WriteLine("OK! vslue is {0}", d);
        }

        static string DownloadWebStr()
        {

            WebClient wc = new WebClient();
            string str = wc.DownloadString("https://www.baidu.com");
            return str;
        }
    }
}
