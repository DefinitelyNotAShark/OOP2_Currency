using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Object_Model_Midterm.Models
{
    interface ICurrency
    {
        float MonetaryValue { get; set; }
        string Name { get; set; }
    }
}
