using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
{
    class Dime: USCoin
    {
        public Dime()
        {
            MonetaryValue = .10f;
            Name = "Dime";
        }

        public Dime(MintMark mark)
        {
            MonetaryValue = .10f;
            Name = "Dime";
            USCoinMintMark = mark;
        }
    }
}
