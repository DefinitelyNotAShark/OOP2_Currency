using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_App_Fixed
{
    public interface ICurrencyRepo
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
