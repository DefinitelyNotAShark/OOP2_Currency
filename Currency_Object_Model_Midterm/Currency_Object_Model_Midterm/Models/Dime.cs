using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Object_Model_Midterm.Models
{
    class Dime : USCoin
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

