using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_App_Fixed
{
    public abstract class Coin : ICoin
    {
        private int year { get; set; }
        private string name { get; set; }
        private double monetaryValue { get; set; }

        public double MonetaryValue
        {
            get { return Math.Round(monetaryValue, 2); }
            set { monetaryValue = value; }
        }

        public int Year
        {
            get { return year; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Coin()
        {
            year = DateTime.Now.Year;
        }

        //public string About()
        //{
        //    return base.About();
        //}
    }
}
