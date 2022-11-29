using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2zhgyakorlo
{
    internal class Stock
    {
        CompanyName company;
        public CompanyName Company
        { get { return company; } }

        DateTime date;
        public DateTime Date
        { get { return date; } }

        double openPrice;
        public double OpenPrice
        { get { return openPrice; } }

        double closePrice;
        public double ClosePrice
        { get { return closePrice; } }

        double highPrice;
        public double HighPrice
        { get { return highPrice; } }

        double lowPrice;
        public double LowPrice
        { get { return lowPrice; } }

        int volume;
        public int Volume
        { get { return volume; } }

        public Stock(CompanyName company, DateTime date, double openPrice, double closePrice, double highPrice, double lowPrice, int volume)
        {
            this.company = company;
            this.date = date;
            this.openPrice = openPrice;
            this.closePrice = closePrice;
            this.highPrice = highPrice;
            this.lowPrice = lowPrice;
            this.volume = volume;
        }

        public override string ToString()
        {
            return $"{Company},{Date.ToShortDateString()},{OpenPrice},{ClosePrice},{HighPrice},{LowPrice},{Volume}";
        }

    }
}
