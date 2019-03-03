using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
{
    public enum MintMark
    {
        P,
        D,
        S,
        W
    }

    abstract class USCoin : Coin
    {

        public MintMark USCoinMintMark;

        public string About()
        {
            return Name + " is from " + Year + ". It is worth " + MonetaryValue + ". It was made in " + GetMintNameFromMark();
        }

        public string GetMintNameFromMark()//Give it to me, Mark!
        {
            switch (USCoinMintMark)
            {
                case MintMark.D:
                    return "Denver";
                case MintMark.P:
                    return "Philadephia";
                case MintMark.S:
                    return "San Francisco";
                case MintMark.W:
                    return "West Point";
            }
            return null;
        }

        public USCoin()
        {
            USCoinMintMark = MintMark.D;
        }
    }
}
