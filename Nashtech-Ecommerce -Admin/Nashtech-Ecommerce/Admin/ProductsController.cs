using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nashtech_Ecommerce.Data;
using Nashtech_Ecommerce.Models;

namespace Nashtech_Ecommerce.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products.OrderBy(s => s.CreatedDate).ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(string id, [FromForm] ProductViewModel product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var fileName = Path.GetFileName(product.FormFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
            using (var fileSrteam = new FileStream(filePath, FileMode.Create))
            {
                await product.FormFile.CopyToAsync(fileSrteam);
            }
            var tempProduct = new Product();
            tempProduct.Id = id;
            tempProduct.Name = product.Name;
            tempProduct.Description = product.Description;
            tempProduct.Price = product.Price;
            tempProduct.PromationPrice = product.PromationPrice;
            tempProduct.Quantity = product.Quantity;
            tempProduct.Image = fileName;
            tempProduct.CategoryID = product.CategoryID;
            tempProduct.UpdatedDate = DateTime.Now;
            _context.Entry(tempProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromForm] ProductViewModel product)
        {
            var fileName = Path.GetFileName(product.FormFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
            using (var fileSrteam = new FileStream(filePath, FileMode.Create))
            {
                await product.FormFile.CopyToAsync(fileSrteam);
            }
            var tempProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PromationPrice = product.PromationPrice,
                Quantity = product.Quantity,
                Image = fileName,
                CategoryID = product.CategoryID,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            _context.Products.Add(tempProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
