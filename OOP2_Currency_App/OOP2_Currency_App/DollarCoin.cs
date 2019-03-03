using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
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
