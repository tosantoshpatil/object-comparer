using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
   public class ListCompare: ICompare
    {

        public bool Comparer<T>(T first, T second)
        {

            bool checkSimilarValue1 = false;
            bool checkSimilarValue2 = false;

            var value1 = first as IEnumerable;
            var value2 = second as IEnumerable;

            foreach (var o in value1)
            {
                checkSimilarValue1 = false;
                foreach (var o2 in value2)
                {
                    if (o.Equals(o2))
                    {
                        checkSimilarValue1 = true;
                        break;
                    }
                }
                if (!checkSimilarValue1)
                {
                    checkSimilarValue1 = false;
                    break;
                }
            }

            foreach (var o in value2)
            {
                checkSimilarValue2 = false;
                foreach (var o2 in value1)
                {
                    if (o.Equals(o2))
                    {
                        checkSimilarValue2 = true;
                        break;
                    }
                }
                if (!checkSimilarValue2)
                {
                    checkSimilarValue2 = false;
                    break;
                }
            }
            if ((checkSimilarValue1 && checkSimilarValue2))
                return true;
            else return false;

        }
    }
}
