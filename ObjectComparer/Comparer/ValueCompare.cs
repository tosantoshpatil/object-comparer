using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
   public class ValueCompare: ICompare
    {
        public bool Comparer<T>(T first, T second)
        {
            return first.Equals(second);
        }
    }
}
