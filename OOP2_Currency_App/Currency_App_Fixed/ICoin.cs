﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_App_Fixed
{
    public interface ICoin : ICurrency
    {
        int Year { get; }
    }
}
