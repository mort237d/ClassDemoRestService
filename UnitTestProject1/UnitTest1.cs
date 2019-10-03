using ClassDemoRestService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib.Model;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        ItemsController itemsController = new ItemsController();

        [TestMethod]
        public void TestGet()
        {
            Assert.AreEqual(5, itemsController.Get().Count());
        }

        [TestMethod]
        public void TestGetID()
        {
            Assert.AreEqual("Bread", itemsController.Get(1).Name);
        }

        [TestMethod]
        public void TestPost()
        {
            itemsController.Post(new Item(6, "Coffee", "High", 23));
            Assert.AreEqual(6, itemsController.Get().Count());
            itemsController.Delete(6);
        }

        [TestMethod]
        public void TestPut()
        {
            itemsController.Put(1, new Item(1, "Cookie", "Low", 33));
            Assert.AreEqual("Cookie", itemsController.Get(1).Name);
        }

        [TestMethod]
        public void TestDelete()
        {
            itemsController.Delete(1);
            Assert.AreEqual(4, itemsController.Get().Count());
            itemsController.Post(new Item(1, "Bread", "Low", 33));
        }

        [TestMethod]
        public void TestGetFromSubstring()
        {
            Assert.AreEqual(2, itemsController.GetFromSubstring("Bread").Count());
        }

        [TestMethod]
        public void TestGetFromQuality()
        {
            Assert.AreEqual(3, itemsController.GetFromQuality("Low").Count());
        }

        [TestMethod]
        public void TestGetWithFilter()
        {
            Assert.AreEqual(2, itemsController.GetWithFilter(new FilterItem(20, 30)).Count());
        }
    }
}
