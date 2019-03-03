using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
{
    class Nickel : USCoin
    {
        public Nickel()
        {
            MonetaryValue = .05f;
            Name = "Nickel";
        }

        public Nickel(MintMark mark)
        {
            MonetaryValue = .05f;
            Name = "Nickel";
            USCoinMintMark = mark;
        }
    }
}
