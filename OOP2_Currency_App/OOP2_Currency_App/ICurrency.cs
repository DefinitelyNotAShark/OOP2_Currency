using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
{
    interface ICurrency
    {
        float MonetaryValue { get; set; }
        string Name { get; set; }
    }
}
