using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nashtech_Ecommerce.Data;
using Nashtech_Ecommerce.Models;
using Newtonsoft.Json;

namespace Nashtech_Ecommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var comments = await _context.Ratings.Where(s => s.ProductId == id).ToListAsync();
            ViewBag.Comments = comments;

            var ratings = await _context.Ratings.Where(s => s.ProductId.Equals(id)).ToListAsync();
            if(ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rate);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.categories = categories;
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,PromationPrice,Quantity,Image,CreatedDate,UpdatedDate,CategoryID")] Product product, IFormFile uploadFile)
        {

            if (ModelState.IsValid)
            {
                if (uploadFile != null && uploadFile.Length > 0)
                {
                    var fileName = Path.GetFileName(uploadFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    product.Image = fileName;

                    _context.Add(product);
                    await _context.SaveChangesAsync();


                    using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(fileSrteam);
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = await _context.Categories.ToListAsync();
            ViewBag.categories = categories;
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,Price,PromationPrice,Quantity,Image,CreatedDate,UpdatedDate,CategoryID")] Product product, IFormFile uploadFile)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fileName = Path.GetFileName(uploadFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    product.Image = fileName;


                    using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(fileSrteam);
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("productcategory/{id}")]
        public async Task<IActionResult> ProductCategory(string id)
        {
            //var cateId = await _context.Categories.Where(s => id);
            if (id == null)
            {
                return View();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return View();
            }
            var products = await _context.Products.Where(s => s.CategoryID == id).ToListAsync();
            //ViewBag.products = products;
            return View(products);
        }



        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.Id == id);
        }


        // My cart


        // Key lưu chuỗi json của Cart
        public const string CARTKEY = "cart";

        // Lấy cart từ Session (danh sách CartItem)
        List<CartItem> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Xóa cart khỏi session
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        /// Thêm sản phẩm vào cart
        //[HttpPost]
        //[Route("Products/addcart/{id}")]
        public IActionResult AddToCart(string id)
        {

            var product = _context.Products
                            .Where(p => p.Id == id)
                            .FirstOrDefault();
            if (product == null)
                return NotFound("Không có sản phẩm");
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == id);
            if (cartitem != null)
            {
                cartitem.quantity++;
            }
            else
            {
                cart.Add(new CartItem() { quantity = 1, product = product });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }


        [Route("/removecart/{id}")]
        public IActionResult RemoveCart([FromRoute] string id)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == id);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }

        /// Cập nhật
        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] string productid, [FromForm] int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity = quantity;
            }
            SaveCartSession(cart);
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return Ok();
        }



        [HttpGet]
        [Route("/cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }

    }
}
