using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_App_Fixed
{
    public class Quarter : USCoin
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
