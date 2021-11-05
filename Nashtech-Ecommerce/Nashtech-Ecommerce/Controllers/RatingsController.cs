using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nashtech_Ecommerce.Data;
using Nashtech_Ecommerce.Models;

namespace Nashtech_Ecommerce.Controllers
{
    public class RatingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RatingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Ratings
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email
            return View(await _context.Ratings.ToListAsync());
        }

        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Ratings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var comment = form["Comment"].ToString();
            var productId = form["ProductId"].ToString();
            var rating = int.Parse(form["Rating"]);
            //var Name = form["Name"].ToString();

            var rate = new Rating()
            {
                Comment = comment,
                Rate = rating,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = productId,
                UserId = userId,
            };



            _context.Add(rate);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Products", new { id = productId });
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Comment,Rate,CreatedDate,UpdatedDate,UserId,ProductId")] Rating rating)
        {
            if (id != rating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.Id))
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
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Ratings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(string id)
        {
            return _context.Ratings.Any(e => e.Id == id);
        }
    }
}
