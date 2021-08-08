using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDistinct.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDistinctTests.Common;

namespace TestDistinct.Service.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        [TestMethod()]
        public void TestprivateMethod()
        {
            var instance = new ProductService();
            var listProd = new List<Product>();
            
            var result = PrivateMethod.CallPrivateMethod<ProductService, List<Product>, (string code,List<Product> list)>(instance, "privateMethod", listProd);
        }
    }
}