using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
   public class CompareFactory<T>
    {
        public T ComparerType { get; set; }
        string objectType = null;
        public string getType()
        {
            var IsvalueType = this.ComparerType.GetType().IsValueType;

            if (IsvalueType)
            {
                objectType = Common.ObjectType.ValueType.ToString() ;
            }
            else
            {

                var ObjectType = this.ComparerType.GetType().Name;
                if (this.ComparerType.GetType().Name == Common.ObjectType.String.ToString())
                {
                    objectType = Common.ObjectType.String.ToString();
                }
                else if (this.ComparerType.GetType().BaseType.Name == Common.ObjectType.Object.ToString())
                {
                    objectType = Common.ObjectType.Object.ToString();

                }
                else if (this.ComparerType.GetType().BaseType.Name == Common.ObjectType.Array.ToString())
                {
                    objectType = Common.ObjectType.Array.ToString();
                }
            }

            return objectType;
        }

        public ICompare GetObject(string objectType)
        {
            if (objectType == Common.ObjectType.ValueType.ToString() || objectType == Common.ObjectType.String.ToString())
                return new ValueCompare();
            else if (objectType == Common.ObjectType.Array.ToString())
                return new ArrayCompare();
            else if (objectType == Common.ObjectType.Object.ToString())
                return new ObjectCompare();
            else if (objectType == Common.ObjectType.List.ToString())
                return new ListCompare();
            else
                return new DefaultCompare();
        }
    }
}
