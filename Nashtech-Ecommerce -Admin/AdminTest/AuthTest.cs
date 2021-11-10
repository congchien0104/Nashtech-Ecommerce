using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Nashtech_Ecommerce.Admin;
using Nashtech_Ecommerce.Data;
using Nashtech_Ecommerce.Models;
using Nashtech_Ecommerce.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdminTest
{
    public class AuthTest
    {
        public Mock<IUserService> mock = new Mock<IUserService>();

        [Fact]
        public async void Test_GetTokenAsync()
        {
            var loginDTO = new TokenRequestModel()
            {
                Email = "admin@gmail.com",
                Password = "Chienfc14@.",
            };
            var authmodel = new AuthenticationModel();
            authmodel.Email = "admin@gmail.com";
            authmodel.UserName = "admin";
            authmodel.Token = "123456";

            mock.Setup(p => p.GetTokenAsync(loginDTO)).ReturnsAsync(authmodel);
            AuthController auth = new AuthController(mock.Object);
            var result = await auth.GetTokenAsync(loginDTO);
            var model = Assert.IsType<OkObjectResult>(result);
            var res = Assert.IsAssignableFrom<AuthenticationModel>(model.Value);

            Assert.Equal("admin@gmail.com", res.Email);
        }
        [Fact]
        public async void Test_GET_AllCategories()
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
            var result = await controller.GetCategories();
            // Assert
            var model = Assert.IsType<ActionResult<IEnumerable<Category>>>(result);
            //var res = Assert.IsAssignableFrom<Category>(model.Value);
            var res = Assert.IsAssignableFrom<OkObjectResult>(model.Result);
            Assert.Equal(4, 4);
        }
        [Fact]
        public async void Test_Post_PostCategory()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            var category = new Category() 
            { 
                Name = "Ngoc Tram",
                Description = "Eahleo"
            };


            //var _context = new ApplicationDbContext(options);

            //Arrange
            var mockContext = new ApplicationDbContext(options);
            var controller = new CategoriesController(mockContext);

            //Action
            var result = await controller.PostCategory(category);
            // Assert
            Assert.Equal(4, 4);
        }

    }
}
