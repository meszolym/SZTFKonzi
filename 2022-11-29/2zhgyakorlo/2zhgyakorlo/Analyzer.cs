using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2zhgyakorlo
{
    internal class Analyzer
    {
        private readonly Stock[] Dataset;

        public Analyzer()
        {
            Dataset = StockDataset.Load("apple.stock", "alphabet.stock", "meta.stock");
        }

        public Stock GetHighetsClosePrice(CompanyName company)
        {
            int maxindex = 0;
            for (int i = 0; i < this.Dataset.Length; i++)
            {
                if (this.Dataset[i].Company == company && this.Dataset[i].ClosePrice > this.Dataset[maxindex].ClosePrice)
                {
                    maxindex = i;
                }
            }
            return this.Dataset[maxindex];
        }
        public double[] GetOpenPriceByDate(DateTime day)
        {
            double[] OpenPrices = new double[3];

            for (int i = 0; i<= this.Dataset.Length; i++)
            {
                if (this.Dataset[i].Date == day)
                {
                    if (this.Dataset[i].Company == CompanyName.AppleInc)
                    {
                        OpenPrices[0] = this.Dataset[i].OpenPrice;
                    }
                    else if (this.Dataset[i].Company == CompanyName.AlphabetInc)
                    {
                        OpenPrices[1] = this.Dataset[i].OpenPrice;
                    }
                    else if (this.Dataset[i].Company == CompanyName.MetaPlatformInc)
                    {
                        OpenPrices[2] = this.Dataset[i].OpenPrice;
                    }
                }
                
            }
            return OpenPrices;

        }

        public int NbrOfEntries()
        {
            return this.Dataset.Length; //itt igazából a napokatt le kellene számolni, ez "HF", vagy excercise for the reader :)
        }
        public double GetChange(CompanyName company, int year)
        {
            int maxindex = 0; //utolsó nap
            int minindex = 0; //első nap

            for (int i = 0; i< this.Dataset.Length; i++)
            {
                if (this.Dataset[i].Company == company)
                {
                    if (this.Dataset[i].Date > this.Dataset[maxindex].Date && this.Dataset[i].Date.Year == year)
                    {
                        maxindex = i;
                    }
                    if (this.Dataset[i].Date < this.Dataset[minindex].Date && this.Dataset[i].Date.Year == year)
                    {
                        minindex = i;
                    }
                }
            }
            double csokkenes = this.Dataset[minindex].OpenPrice - this.Dataset[maxindex].ClosePrice;
            return csokkenes * -1;
        }

        public double Risk(CompanyName company, DateTime start, DateTime stop, int ammount) 
        {
            double startprice = 0;
            double endprice = 0;
            for (int i = 0; i<this.Dataset.Length; i++)
            {
                if (this.Dataset[i].Company == company)
                {
                    if (this.Dataset[i].Date == start)
                    {
                        startprice = this.Dataset[i].LowPrice;
                    }
                    if (this.Dataset[i].Date == stop)
                    {
                        endprice = this.Dataset[i].HighPrice;
                    }
                }
            }

            double pricePaid = ammount * startprice;
            double priceIncome = ammount * endprice;

            return priceIncome - pricePaid;

        }

    }
}
