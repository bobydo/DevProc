using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDistinct.Service
{
    public class ProductService
    {

        private (string result, List<Product> listProduct) privateMethod(List<Product> getListProduct)
        {
            return ("Success", new List<Product>());
        }
    }
}
