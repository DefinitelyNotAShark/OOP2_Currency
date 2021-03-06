﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_App_Fixed
{
    public enum MintMark
    {
        P,
        D,
        S,
        W
    }

    public abstract class USCoin : Coin
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

        public static string GetMintNameFromMark(MintMark mark)//Give it to me, Mark!
        {
            switch (mark)
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
