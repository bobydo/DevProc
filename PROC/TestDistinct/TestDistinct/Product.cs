using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDistinct
{
    public class Product : IEquatable<Product>
    {
        public string Name { get; set; }
        public int? Code { get; set; }

        public bool? IsPublished { get; set; }


        public bool Equals(Product other)
        {

            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return Code.Equals(other.Code) && Name.Equals(other.Name) && IsPublished.Equals(other.IsPublished);
        }
    }
}
