using NUnit.Framework;
using TSD.Linq.Task1.Lib;
using TSD.Linq.Task1.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TSD.Linq.Task1.Lib.Test
{
    public class SimpleTests
    {
        GoldClient goldClient;

        [SetUp]
        public void Setup()
        {
            goldClient = new GoldClient();
        }

        [Test]
        public void CurrentPriceNotNullTest()
        {
            GoldPrice currentPrice = goldClient.GetCurrentGoldPrice().GetAwaiter().GetResult();

            Assert.IsNotNull(currentPrice);
            Assert.IsNotNull(currentPrice.Price);
            Assert.Greater(currentPrice.Price, 0.0);
            Assert.AreEqual(DateTime.Now.ToShortDateString(), currentPrice.Date.ToShortDateString());
            

          
        }

        [Test]
        public void GetGoldPricesNotNullTest()
        {
            List<GoldPrice> thisYearPrices = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 03, 17)).GetAwaiter().GetResult();

            Assert.IsNotNull(thisYearPrices);
            Assert.Greater(thisYearPrices.Count, 0);
        }
        [Test]
        public void Task2()
        {
            List<GoldPrice> thisYearPrices = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();
            IEnumerable<GoldPrice> goldPricesMin = thisYearPrices.OrderBy(x => x.Price).ToArray().Take(3);
            IEnumerable<GoldPrice> goldPricesMax = thisYearPrices.OrderBy(x => -x.Price).ToArray().Take(3);
            foreach (GoldPrice goldPrice in goldPricesMin)
            {
                Console.WriteLine("Min {0},{1}", goldPrice.Price, goldPrice.Date);
            }
            foreach (GoldPrice goldPrice in goldPricesMax)
            {
                Console.WriteLine("Max {0},{1}", goldPrice.Price, goldPrice.Date);
            }

        }
        [Test]
        public void Task3()
        {
            List<GoldPrice> thisYearPrices = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
            IEnumerable<GoldPrice> goldPricesJan = thisYearPrices.Where(x=>x.Date.Month==1).ToList();
            List<GoldPrice> selectedPrices = new List<GoldPrice> ();
            foreach(GoldPrice goldPrice in goldPricesJan)
            {
                IEnumerable<GoldPrice> temp = thisYearPrices.Where(x => x.Price/goldPrice.Price > 1.05).ToList();
                selectedPrices.AddRange(temp);
            }
            selectedPrices=selectedPrices.Distinct().ToList(); 
            foreach (GoldPrice goldPrice in selectedPrices)
            {
                Console.WriteLine("{0},{1}", goldPrice.Price, goldPrice.Date);
            }


        }
        [Test]
        public void Task4()
        {
            List<GoldPrice> allYearsPirces = new List<GoldPrice>();
            List<GoldPrice> Year2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
            List<GoldPrice> Year2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
            List<GoldPrice> Year2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();
            foreach (GoldPrice price in Year2019)
            {
                allYearsPirces.Add(price);
            }
            foreach (GoldPrice price in Year2020)
            {
                allYearsPirces.Add(price);
            }
            foreach (GoldPrice price in Year2021)
            {
                allYearsPirces.Add(price);

            }
            var count = allYearsPirces.Count();
            count = (int)(count * 0.2);
            IEnumerable<GoldPrice> goldPrices10 = allYearsPirces.OrderBy(x => -x.Price).ToList().Skip(count).Take(3);

            foreach (GoldPrice goldPrice in goldPrices10)
            {
                Console.WriteLine("{0},{1}", goldPrice.Price, goldPrice.Date);
            }



        }
        [Test]
        public void Task8()
        {
            List<GoldPrice> Year2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
            List<GoldPrice> Year2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
            List<GoldPrice> Year2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();

            var count2019 = Year2019.Select(x => x.Price).Average();
            var count2020 = Year2020.Select(x => x.Price).Average();
            var count2021 = Year2021.Select(x => x.Price).Average();

            
            Console.WriteLine("2019 {0}", count2019);
            Console.WriteLine("2020 {0}", count2020);
            Console.WriteLine("2021 {0}", count2021);

        }

        [Test]
        public void Task9()
        {
            List<GoldPrice> allYearsPrices = new List<GoldPrice>();
            List<GoldPrice> Year2019 = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
            List<GoldPrice> Year2020 = goldClient.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
            List<GoldPrice> Year2021 = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 12, 31)).GetAwaiter().GetResult();
            foreach (GoldPrice price in Year2019)
            {
                allYearsPrices.Add(price);
            }
            foreach (GoldPrice price in Year2020)
            {
                allYearsPrices.Add(price);
            }
            foreach (GoldPrice price in Year2021)
            {
                allYearsPrices.Add(price);

            }
            var goldPrices = allYearsPrices.Select(x => new { date = x.Date, roi = allYearsPrices.Select(y => new GoldPrice { Price = (y.Price - x.Price)/x.Price*100,Date=y.Date }).OrderBy(z=>-z.Price).Take(1)}).OrderBy(xx=>-xx.roi.First().Price).Take(1).ToList();

           foreach(var gp in goldPrices) { 

                Console.WriteLine("Buy:{0},Sell:{2},Roi:{1}",gp.date,gp.roi.First().Price, gp.roi.First().Date);
            }



        }
        [Test]
        public void Task12()
        {
            List<GoldPrice> PriceList = goldClient.GetGoldPrices(new DateTime(2019, 01, 01), new DateTime(2019, 12, 31)).GetAwaiter().GetResult();
            XDocument xml = new XDocument(
                new XComment($"Gold prices"),
                new XElement("GoldPrices",
                    PriceList.Select(x => new XElement("GoldPrice",
                            new XElement("Date", x.Date.ToString("o")),
                            new XElement("Price", x.Price.ToString())
                        )
                    )
                )
            );
            xml.Save("goldprices.xml"); 
        }
        [Test]
        public void Task13()
        {
            
            var PL = XDocument.Load("goldprices.xml").Root.Elements().Select(x=>new GoldPrice { Date=Convert.ToDateTime(x.Descendants().First().Value),Price= Convert.ToDouble(x.Descendants().Last().Value)});
            foreach (var goldPrice in PL)
            {

                Console.WriteLine("{0},{1}", goldPrice.Date,goldPrice.Price);
            }

        }






    }
}