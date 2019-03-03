using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2_Currency_App
{
    interface ICoin : ICurrency
    {
        int Year { get; }
    }
}
