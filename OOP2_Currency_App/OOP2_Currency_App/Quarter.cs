using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
{
    class Quarter : USCoin
    {
        public Quarter()
        {
            MonetaryValue = .25f;
            Name = "Quarter";
        }

        public Quarter(MintMark mark)
        {
            MonetaryValue = .25f;
            Name = "Quarter";
            USCoinMintMark = mark;
        }
    }
}
