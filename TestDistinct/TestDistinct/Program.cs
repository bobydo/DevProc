using MCTWF.BusinessObjects.EBT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDistinct
{
    class Program
    {
        static void Main(string[] args)
        {
            //Distinct();
            //ToListTest();
            string textFile = "..\\..\\File\\LOCKA20210720150343.txt";
            string filterString = "S";
            var ReturnInfo = ProcessFile(textFile, filterString);

            Console.ReadLine();
        }

        private static string ProcessFile(string textFile, string filterString)
        {
            string ReturnInfo = "Success";
            string[] lines = File.ReadAllLines(textFile);
            List<String> linesRecords = lines.Where(l => l.Contains(filterString)).ToList();
            if (linesRecords == null || linesRecords.Count() == 0)
                ReturnInfo = "No S lines in file!";
            int evenNumberRow = linesRecords.Count() % 2;
            if (evenNumberRow != 0)
                ReturnInfo = "The nubmer of S lines is odd number";
            int loopNumber = linesRecords.Count() / 2;
            List<EmployerBalanceCreditDto> listEmployerBalanceCredit = new List<EmployerBalanceCreditDto>();
            for (int i = 0; i < loopNumber; i++)
            {
                int firstRow = i * 2;
                int secondRow = i * 2 + 1;
                EmployerBalanceCreditDto ebc = new EmployerBalanceCreditDto();
                ebc.Agreement = "";
                ebc.Area = "";
                ebc.AssessmentType = "";
                ebc.Association = "";
                ebc.Comment = "";
                ebc.Contract = "";
                ebc.Fund = "W";
                ebc.Group = "";
                ebc.Local = "";
                ebc.Location = "";
                ebc.PayrollFromDate = DateTime.Now.AddDays(-30);
                ebc.PayrollThruDate = DateTime.Now;
                ebc.ReceivedDate = DateTime.Now;
                ebc.TransactionDate = DateTime.Now;
                ebc.EmployerNumber = PropertyMapping(linesRecords[firstRow], "EmployerNumber");
                ebc.Amount = Decimal.Parse(GetDecimal(PropertyMapping(linesRecords[firstRow], "Amount")));
                ebc.DepositDate = DateTime.ParseExact("20" + PropertyMapping(linesRecords[firstRow], "DepositDate"),
                    "yyyyMMdd", CultureInfo.InvariantCulture);
                //ebc.DepositDate = DateTime.Parse("20"+PropertyMapping(linesRecords[firstRow], "DepositDate"));
                ebc.CheckNumber = PropertyMapping(linesRecords[secondRow], "CheckNumber");
                Console.WriteLine(linesRecords[firstRow]);
                Console.WriteLine(linesRecords[secondRow]);
            }

            return ReturnInfo;
        }

        private static string GetDecimal(string amountString)
        {
            var length = amountString.Length;
            amountString = amountString.Substring(0, length - 3) + "." + amountString.Substring(length - 3, 2);
            return amountString;
        }

        private static string PropertyMapping(string line, string Property)
        {
            var dict = new Dictionary<string, Tuple<int, int>>(){
                    { "EmployerNumber", new Tuple<int,int>(33, 4)},
                    { "Amount", new Tuple<int,int>(49, 11)},
                    { "DepositDate", new Tuple<int,int>(17, 6)},
                    { "CheckNumber", new Tuple<int,int>(13, 5)}
                };
            var startIndex = dict[$"{Property}"].Item1;
            var length = dict[$"{Property}"].Item2;
            return line.Substring(startIndex, length);
        }


        private static void ToListTest()
        {
            List<Product> listProduct = new List<Product>()
            {
                new Product { Name = "apple", Code = 9, IsPublished=true},
                new Product { Name = "orange", Code = 4 , IsPublished=true},
                new Product { Name = "apple", Code = 9 , IsPublished=true},
                new Product { Name = "lemon", Code = 12 , IsPublished=true},
                new Product { Name = "shenyi", Code = null, IsPublished=null },
                new Product { Name = "jian", Code = null,IsPublished=null }
            };

            //remove .ToList() shows error colleciton is modified
            foreach (var item in listProduct.ToList())
            {
                if (item.Name == "apple" || item.Name == "shenyi")
                    listProduct.Remove(item);
            }
            foreach (var item in listProduct.ToList())
            {
                Console.WriteLine($"{item.Name}");
            }

            Collection<Product> colProduct = new Collection<Product>()
            {
                new Product { Name = "apple", Code = 9, IsPublished=true},
                new Product { Name = "orange", Code = 4 , IsPublished=true},
                new Product { Name = "apple", Code = 9 , IsPublished=true},
                new Product { Name = "lemon", Code = 12 , IsPublished=true},
                new Product { Name = "shenyi", Code = null, IsPublished=null },
                new Product { Name = "jian", Code = null,IsPublished=null }
            };

            Console.WriteLine("\r\n\r\n");

            //foreach (var item in colProduct)
            //{
            //    if (item.Name == "apple" || item.Name == "shenyi")
            //        colProduct.Remove(item);
            //}
            //foreach (var item in colProduct)
            //{
            //    Console.WriteLine($"{item.Name}");
            //}
        }

        private static void Distinct()
        {
            Product[] products = { new Product { Name = "apple", Code = 9, IsPublished=true},
                       new Product { Name = "orange", Code = 4 , IsPublished=true},
                       new Product { Name = "apple", Code = 9 , IsPublished=true},
                       new Product { Name = "lemon", Code = 12 , IsPublished=true},
                    new Product { Name = "shenyi", Code = null, IsPublished=null },
                new Product { Name = "shenyi", Code = null,IsPublished=null }};


            IEnumerable<Product> noduplicates =
            products.Distinct(new ProductComparer());

            foreach (var product in noduplicates)
                Console.WriteLine(product.Name + " " + product.Code);
            int count = 0;
            for (; count < 10; count++)
            {
                Console.WriteLine(count);
            }
        }
    }
}
