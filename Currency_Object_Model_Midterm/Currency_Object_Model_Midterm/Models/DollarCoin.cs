using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Object_Model_Midterm.Models
{
    class DollarCoin : USCoin
    {
        public DollarCoin()
        {
            MonetaryValue = 1f;
            Name = "Dollar Coin";
        }

        public DollarCoin(MintMark mark)
        {
            MonetaryValue = 1f;
            Name = "Dollar Coin";
            USCoinMintMark = mark;
        }
    }
}
