using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_App_Fixed
{
    public class Penny : USCoin
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
