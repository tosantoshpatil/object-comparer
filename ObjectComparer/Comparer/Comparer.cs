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
            catch (Exception  )
            {

                throw;
            }
           
        }
        public static bool AreSimilar<T>(List<T> first, List<T> second){

            if (first == null && second == null)
                return true;
            if (first == null & second != null)
                return false;
            if (first != null & second == null)
                return false;

            if (first.Count != second.Count)
                return false;

            var Ismatch = false;
            int?[] matchelement = new int?[first.Count];
            for (int i = 0; i < first.Count; i++)
            {
                Ismatch = false;
                for (int j = 0; j < second.Count; j++)
                {

                    if (AreSimilar(first[i], second[j]) && !matchelement.Contains(j))
                    {
                        Ismatch = true;
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
