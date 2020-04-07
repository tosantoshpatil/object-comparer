using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
   public class ObjectCompare: ICompare
    {
        public bool Comparer<T>(T first, T second)
        {
            PropertyInfo[] sourceProperties = first.GetType().GetProperties();
            bool checkSimilar = true;
            foreach (PropertyInfo pi in sourceProperties)
            {

                var fvalue = pi.GetValue(first);
                var svalue = pi.GetValue(second);

                if (pi.PropertyType.IsValueType)
                {
                    checkSimilar = fvalue.Equals(svalue);

                    if (!checkSimilar)
                        return false;
                }
                else if (pi.PropertyType.Name == Common.ObjectType.String.ToString())
                {
                    checkSimilar = fvalue.Equals(svalue);
                    if (!checkSimilar)
                        return false;
                }
                else if (pi.PropertyType.BaseType.Name == Common.ObjectType.Array.ToString())
                {
                    ArrayCompare arrayComparer = new ArrayCompare();
                    if (!arrayComparer.Comparer(pi.GetValue(first) as Array, pi.GetValue(second) as Array))
                        return false;
                }

            }

            return true;
        }
    }
}
