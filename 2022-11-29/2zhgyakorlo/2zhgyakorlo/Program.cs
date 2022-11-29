using System;

namespace _2zhgyakorlo
{

    enum CompanyName
    {
        AppleInc = 10,
        AlphabetInc = 20,
        MetaPlatformInc = 30
    }

    internal class Program
    {



        static void Main(string[] args)
        {
            Stock stock = new Stock(CompanyName.AppleInc,DateTime.Today, 0.1,1.1,2.1,0.0,15);
            Console.WriteLine(stock.ToString());
        }
    }
}
