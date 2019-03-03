using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
{
    abstract class Coin : ICoin
    {
        private int year { get; set; }
        private string name { get; set; }
        private float monetaryValue { get; set; }

        public float MonetaryValue
        {
            get { return monetaryValue; }
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
