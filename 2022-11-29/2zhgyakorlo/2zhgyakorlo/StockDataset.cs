using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2zhgyakorlo
{
    internal static class StockDataset
    {
        public static Stock[] Load(string apple, string alphabet, string meta)
        {
            //$"{Company},{Date.ToShortDateString()},{OpenPrice},{ClosePrice},{HighPrice},{LowPrice},{Volume}";
            int numoflines = 0;
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(apple);
            while(!sr.EndOfStream)
            {
                sb.AppendLine(sr.ReadLine());
                numoflines++;
            }
            sr.Close();
            sr = new StreamReader(alphabet);
            while (!sr.EndOfStream)
            {
                sb.AppendLine(sr.ReadLine());
                numoflines++;
            }
            sr.Close();
            sr = new StreamReader(meta);
            while (!sr.EndOfStream)
            {
                sb.AppendLine(sr.ReadLine());
                numoflines++;
            }
            sr.Close();

            Stock[] stocks= new Stock[numoflines];

            string input = sb.ToString();

            string[] lines = input.Split(Environment.NewLine);
            
            for (int i = 0; i< lines.Length; i++)
            {
                string[] stockdata = lines[i].Split(",");

                CompanyName company = CompanyName.AppleInc;

                if (stockdata[0] == "MetaPlatformInc")
                {
                    company = CompanyName.MetaPlatformInc;
                }
                else if (stockdata[0] == "AlphabetInc")
                {
                    company = CompanyName.AlphabetInc;
                }

                stocks[i] = new Stock(company, DateTime.Parse(stockdata[1]),
                    double.Parse(stockdata[2]), double.Parse(stockdata[3]), double.Parse(stockdata[4]), double.Parse(stockdata[5]), int.Parse(stockdata[6]));

            }

            return stocks;
        }



        public static void Save(string filename, Stock[] dataset) 
        {
            StreamWriter sw = new StreamWriter(filename);
            for (int i = 0; i< dataset.Length; i++)
            {
                sw.WriteLine(dataset[i].ToString());
            }
            sw.Close();
        }
    }
}
