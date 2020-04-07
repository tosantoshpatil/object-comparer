using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second )
        {
            try
            {
                if (first == null && second == null)
                    return true;
                if (first == null & second != null)
                    return false;
                if (first != null & second == null)
                    return false;

                CompareFactory<T> objFactory = new CompareFactory<T>();
                objFactory.ComparerType = first;
                string ObjectType = objFactory.getType();
                ICompare obj = objFactory.GetObject(ObjectType);
                return obj.Comparer(first, second);
            }
            catch (Exception )
            {

                throw;
            }
           
        }
    }
}
