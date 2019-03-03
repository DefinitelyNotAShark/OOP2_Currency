using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
{
    class Penny : USCoin
    {
        public Penny()
        {
            MonetaryValue = .01f;
            Name = "Penny";
        }

        public Penny(MintMark mark)
        {
            MonetaryValue = .01f;
            Name = "Penny";
            USCoinMintMark = mark;
        }
    }
}
