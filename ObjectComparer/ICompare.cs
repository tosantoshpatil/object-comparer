﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
  public  interface ICompare
    {
        bool Comparer<T>(T first, T second);
    }
}
