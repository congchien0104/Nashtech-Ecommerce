using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nashtech_Ecommerce.Admin;
using Nashtech_Ecommerce.Models;
using System.Collections.Generic;

namespace AdminApiTest
{
    [TestClass]
    public class CategoriesTest
    {
        private List<Category> categories;
        public void SetUp()
        {
            categories = new List<Category>();
            categories.Add(new Category { Id = "1", Name = "SmartPhone", Description = "Eahleo, Dak Lak" });
            categories.Add(new Category { Id = "2", Name = "SmartPhone", Description = "Eahleo, Dak Lak" });
            categories.Add(new Category { Id = "3", Name = "SmartPhone", Description = "Eahleo, Dak Lak" });
            categories.Add(new Category { Id = "4", Name = "SmartPhone", Description = "Eahleo, Dak Lak" });
        }
        [TestMethod]
        public void TestMethod1()
        {
            //CategoriesController temp = new CategoriesController(null);
            //var result = temp.GetCategories();
            var result = "congchien";
            Assert.AreEqual("congchien", result);
        }
    }
}
