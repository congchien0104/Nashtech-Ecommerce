using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nashtech_Ecommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nashtech_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // View Customers
        [HttpGet]
        [Route("/customers")]
        public async Task<IActionResult> getCustomer()
        {
            return Ok();
        }
    }
}
