using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nashtech_Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Nashtech_Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace Nashtech_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public const int ITEMS_PER_PAGE = 6;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int pageNumber)
        {
            var products = await _context.Products.ToListAsync();

            //var totalItems = products.Count();
            //// Tính số trang hiện thị (mỗi trang hiện thị ITEMS_PER_PAGE mục)
            //int totalPages = (int)Math.Ceiling((double)totalItems / ITEMS_PER_PAGE);
            //if (totalPages < 1) totalPages = 1;
            //if (pageNumber == 0) pageNumber = 1;

            //if (pageNumber > totalPages)
            //{
            //    return RedirectToRoute("Home", "Index");
            //}


            //// Chỉ lấy các Post trang hiện tại  (theo pageNumber)
            //products = products
            //    .Skip(ITEMS_PER_PAGE * (pageNumber - 1))
            //    .Take(ITEMS_PER_PAGE)
            //    .OrderByDescending(p => p.Name).ToList();

            //ViewData["pageNumber"] = pageNumber;
            //ViewData["totalPages"] = totalPages;

            return View(products);
        }



        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
