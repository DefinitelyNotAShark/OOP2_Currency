using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Object_Model_Midterm.Models
{
    [Serializable]
    public class DollarCoin : USCoin
    {
        public DollarCoin()
        {
            MonetaryValue = 1;
            Name = "Dollar Coin";
        }

        public DollarCoin(MintMark mark)
        {
            MonetaryValue = 1;
            Name = "Dollar Coin";
            USCoinMintMark = mark;
        }
    }
}
