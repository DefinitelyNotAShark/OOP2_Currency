using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_App_Fixed
{
    public class CurrencyRepo : ICurrencyRepo
    {
        public List<ICoin> Coins { get; set; }

        public CurrencyRepo()
        {
            Coins = new List<ICoin>();
        }

        public string About()//tells you how many coins it contains and the type of each
        {
            string s = "Repo has " + Coins.Count + " coins. COINS:";

            for (int i = 0; i < Coins.Count; i++)
            {
                s += "\n" + Coins[i].GetType();
            }

            return s;
        }

        public void AddCoin(ICoin c)
        {
            Coins.Add(c);
        }

        public int GetCoinCount()
        {
            return Coins.Count;
        }

        public ICurrencyRepo CreateChange(double amount)
        {
            CurrencyRepo repo = new CurrencyRepo();
            while (amount > 0)
            {
                if (amount >= 1)//if it's divisible by 100
                {
                    DollarCoin d = new DollarCoin();
                    repo.AddCoin(d);
                    amount -= Math.Round(d.MonetaryValue, 2);
                }
                else if (amount >= .25f)
                {
                    Quarter q = new Quarter();
                    repo.AddCoin(q);
                    amount -= Math.Round(q.MonetaryValue, 2);
                }
                else if (amount >= .10f)
                {
                    Dime d = new Dime();
                    repo.AddCoin(d);
                    amount -= Math.Round(d.MonetaryValue, 2);
                }
                else if (amount >= .05f)
                {
                    Nickel n = new Nickel();
                    repo.AddCoin(n);
                    amount -= Math.Round(n.MonetaryValue, 2);
                }
                else if (amount >= .01f)
                {
                    Penny p = new Penny();
                    repo.AddCoin(p);
                    amount -= Math.Round(p.MonetaryValue, 2);
                }
            }

            return repo;
        }

        public ICurrencyRepo CreateChange(double amountTendered, double totalCost)
        {
            throw new NotImplementedException();
        }

        public void RemoveCoin(ICoin c)
        {
            Coins.Remove(c);
        }

        public double TotalValue()
        {
            double value = 0;//have a temp number starting at 0

            for (int i = 0; i < Coins.Count; i++)//cycle through as many coins as are in the list
            {
                value += Coins[i].MonetaryValue;//get each coin in the list and add it's value to the temp number
            }

            return value;//return the number with every value from the list added
        }

        public ICurrencyRepo MakeChange(double amount)
        {
            throw new NotImplementedException();
        }

        public ICurrencyRepo MakeChange(double amountTendered, double totalCost)
        {
            throw new NotImplementedException();
        }
    }
}
