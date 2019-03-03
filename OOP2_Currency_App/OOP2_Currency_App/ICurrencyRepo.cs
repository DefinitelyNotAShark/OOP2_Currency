using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
{
    interface ICurrencyRepo
    {
        string About();
        void AddCoin(ICoin c);
        int GetCoinCount();
        double TotalValue();
        void RemoveCoin(ICoin c);

        List<ICoin> Coins { get; set; }
        ICurrencyRepo MakeChange(double amount);
        ICurrencyRepo MakeChange(double amountTendered, double totalCost);
    }
}
