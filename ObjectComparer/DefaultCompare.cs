using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class DefaultCompare : ICompare
    {
        public bool Comparer<T>(T first, T second)
        {
            throw new NotImplementedException("Comparer for this type was not defined, Please contact with adiministrator");
        }
    }
}
