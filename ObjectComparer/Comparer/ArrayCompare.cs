using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
  public  class ArrayCompare: ICompare
    {
        public bool Comparer<T>(T first, T second)
        {
            var a = first as Array;
            var b = second as Array;

            if (a.Length != b.Length)
                return false;

            var Ismatch = false;
            int?[] matchelement = new int?[b.Length];

            for (int i = 0; i < a.Length; i++)
            {
                Ismatch = false;
                for (int j = 0; j < b.Length; j++)
                {
                    if (a.GetValue(i).Equals(b.GetValue(j)))
                    {
                        if (!matchelement.Contains(j))
                        {
                            Ismatch = true;
                        }

                        matchelement[j] = j;
                        break;
                    }
                }
                if (!Ismatch)
                    break;
            }

            return Ismatch;
        }
    }
}
