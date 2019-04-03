using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Object_Model_Midterm.Models
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
