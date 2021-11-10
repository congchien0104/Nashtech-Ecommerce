using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nashtech_Ecommerce.Controllers;
using Nashtech_Ecommerce.Data;
using Nashtech_Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdminTest
{
    public class CustomerTest
    {
        [Fact]
        public async void Test_GetCategories_ValidModelState()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            //// Create mocked Context by seeding Data as per Schema///

            using (var _context = new ApplicationDbContext(options))
            {
                _context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.SaveChanges();
            }

            //Arrange
            var mockContext = new ApplicationDbContext(options);
            var controller = new CategoriesController(mockContext);

            //Action
            var result = await controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Category>>(viewResult.ViewData.Model);
            //Assert
            Assert.Equal(4, model.Count());

        }
        [Fact]
        public async void Test_GetCategory_ValidModelState()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            //// Create mocked Context by seeding Data as per Schema///

            using (var _context = new ApplicationDbContext(options))
            {
                _context.Categories.Add(new Category
                {
                    Id = "123456",
                    Name = "Apple",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.SaveChanges();
            }

            //Arrange
            var mockContext = new ApplicationDbContext(options);
            var controller = new CategoriesController(mockContext);

            //Action
            var result = await controller.Details("123456");
            var viewResult = Assert.IsType<ViewResult>(result);
            var category = Assert.IsAssignableFrom<Category>(viewResult.ViewData.Model);

            //Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal("123456", category.Id);
            Assert.Equal("Apple", category.Name);

        }
        [Fact]
        public async void Test_GetCategory_InvalidModelState()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            //// Create mocked Context by seeding Data as per Schema///

            using (var _context = new ApplicationDbContext(options))
            {
                _context.Categories.Add(new Category
                {
                    Id = "123456",
                    Name = "Apple",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.SaveChanges();
            }

            //Arrange
            var mockContext = new ApplicationDbContext(options);
            var controller = new CategoriesController(mockContext);

            //Action
            var result = await controller.Details(Guid.Empty.ToString());

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }
        [Fact]
        public async void Test_GetProducts_ValidModelState()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            //// Create mocked Context by seeding Data as per Schema///

            using (var _context = new ApplicationDbContext(options))
            {
                _context.Products.Add(new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    Price = 10000000,
                    PromationPrice = 200000,
                    CategoryID = "123",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Products.Add(new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    Price = 10000000,
                    PromationPrice = 200000,
                    CategoryID = "123",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Products.Add(new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    Price = 10000000,
                    PromationPrice = 200000,
                    CategoryID = "123",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
                _context.Products.Add(new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    Price = 10000000,
                    PromationPrice = 200000,
                    CategoryID = "123",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });

                _context.SaveChanges();
            }

            //Arrange
            var mockContext = new ApplicationDbContext(options);
            var controller = new ProductsController(mockContext, null);

            //Action
            var result = await controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.ViewData.Model);
            //Assert
            Assert.Equal(4, model.Count());

        }

        [Fact]
        public async void Test_GetProduct_ValidModelState()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            //// Create mocked Context by seeding Data as per Schema///

            using (var _context = new ApplicationDbContext(options))
            {
                _context.Products.Add(new Product
                {
                    Id = "1",
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    Price = 10000000,
                    PromationPrice = 200000,
                    CategoryID = "123",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });

                _context.SaveChanges();
            }

            //Arrange
            var mockContext = new ApplicationDbContext(options);
            var controller = new ProductsController(mockContext, null);

            
            //Action
            var result = await controller.Details("1");
            var viewResult = Assert.IsType<ViewResult>(result);
            var product = Assert.IsAssignableFrom<Product>(viewResult.ViewData.Model);

            //Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal("1", product.Id);
            Assert.Equal("Tui Sach LV", product.Name);
        }

        [Fact]
        public async void Test_GetProduct_InvalidModelState()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            //// Create mocked Context by seeding Data as per Schema///

            using (var _context = new ApplicationDbContext(options))
            {
                _context.Products.Add(new Product
                {
                    Id = "1",
                    Name = "Tui Sach LV",
                    Description = "Tui sach dat gia nhat the gioi.",
                    Price = 10000000,
                    PromationPrice = 200000,
                    CategoryID = "123",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });

                _context.SaveChanges();
            }

            //Arrange
            var mockContext = new ApplicationDbContext(options);
            var controller = new ProductsController(mockContext, null);


            //Action
            var result = await controller.Details(Guid.Empty.ToString());

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
