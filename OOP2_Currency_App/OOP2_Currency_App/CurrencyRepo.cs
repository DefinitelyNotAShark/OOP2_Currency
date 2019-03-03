using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
{
    class CurrencyRepo : ICurrencyRepo
    {
        public List<ICoin> Coins { get; set; }

        public CurrencyRepo()
        {
            Coins = new List<ICoin>();
        }

        public string About()//tells you how many coins it contains and the type of each
        {
            string s = "Repo has " + Coins.Count + " coins. COINS:";
            
             for(int i = 0; i < Coins.Count; i++)
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

        public ICurrencyRepo MakeChange(double amount)
        {
            CurrencyRepo repo = new CurrencyRepo();

            for (double i = amount; amount > 0; i++)//until we have 0 left to make change for, keep generating coins for change
            {
                if (amount % 1 == 0)//if it's divisible by 100
                {
                    DollarCoin d = new DollarCoin();
                    repo.AddCoin(d);
                }
                else if (amount % .25 == 0)
                {
                    Quarter q = new Quarter();
                    repo.AddCoin(q);
                }
                else if (amount % .10 == 0)
                {
                    Dime d = new Dime();
                    repo.AddCoin(d);
                }
                else if (amount % .05 == 0)
                {
                    Nickel n = new Nickel();
                    repo.AddCoin(n);
                }
                else
                {
                    Penny p = new Penny();
                    repo.AddCoin(p);
                }             
            }
            return repo;
        }

        public ICurrencyRepo MakeChange(double amountTendered, double totalCost)
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

            for(int i = 0; i < Coins.Count; i++)//cycle through as many coins as are in the list
            {
                value += Coins[i].MonetaryValue;//get each coin in the list and add it's value to the temp number
            }

            return value;//return the number with every value from the list added
        }
    }
}
