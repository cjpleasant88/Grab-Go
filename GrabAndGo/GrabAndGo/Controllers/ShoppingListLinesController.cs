using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrabAndGo.Data;
using GrabAndGo.Models;
using Microsoft.AspNetCore.Identity;

namespace GrabAndGo.Controllers
{
    public class ShoppingListLinesController : Controller
    {
        private readonly GrabAndGoContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingListLinesController(GrabAndGoContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ShoppingListLines
        public async Task<IActionResult> Index()
        {

            //var List<ShoppingListLine> = await _context.ShoppingListLine.Where<ShoppingListLine>(l => l.)

            return View(await _context.ShoppingListLine.ToListAsync());
        }

        public async Task<IActionResult> YourList(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);



            return View(_context.ShoppingListLine.Where(p => p.ListID.Equals(user.ListID)));
        }

        public async Task<IActionResult> AddToList(int ProductID, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            //var join = from pid in _context.Product
            //           join cat in _context.Category on pid.CategoryID equals cat.CategoryID
            //           where pid.ProductID == ProductID
            //           select new { name = pid.ProductName, id = pid.ProductID };

            //string name = join.FirstOrDefault(line => line.id == ProductID).name;

            Product product = _context.Product
            .FirstOrDefault(p => p.ProductID == ProductID);

            if (product != null)
            {
                ShoppingListLine line = _context.ShoppingListLine
                    .Where(p => p.ProductID == ProductID && p.ListID.Equals(user.ListID))
                    .FirstOrDefault();

                if (line == null)
                {
                    _context.ShoppingListLine.Add(new ShoppingListLine
                    {
                        ListID = user.ListID,
                        ProductID = ProductID,
                        ProductName = product.ProductName,
                        Quantity = 1
                    });
                }
                else
                {
                    line.Quantity += 1;
                }

            }



            

            //ViewBag.ListID = user.ListID;
            //ViewBag.ProductID = ProductID;
            //ViewBag.Name = name;

            //string name = join.FirstOrDefault(line => line.id == ProductID).name;
            //ViewBag.ListID = ListID;
            //ViewBag.ProductID = ProductID;
            //ViewBag.Name = name;

            //var newitem = new ShoppingListLine
            //{
            //    ListID = user.ListID,
            //    ProductID = ProductID,
            //    ProductName = name,
            //    Quantity = 1
            //};

            //_context.ShoppingListLine.Add(newitem);


            await _context.SaveChangesAsync();

            //return View();
            return RedirectToAction("YourList", "ShoppingListLines", new { userName = user.Email });
        }

        // GET: ShoppingListLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingListLine = await _context.ShoppingListLine
                .FirstOrDefaultAsync(m => m.ShoppingListLineID == id);
            
            if (shoppingListLine == null)
            {
                return NotFound();
            }
            return View(shoppingListLine);
        }

        // GET: ShoppingListLines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingListLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingListLineID,ListID,ProductID,ProductName,Quantity")] ShoppingListLine shoppingListLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingListLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingListLine);
        }

        // GET: ShoppingListLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingListLine = await _context.ShoppingListLine.FindAsync(id);
            if (shoppingListLine == null)
            {
                return NotFound();
            }
            return View(shoppingListLine);
        }

        // POST: ShoppingListLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingListLineID,ListID,ProductID,Quantity")] ShoppingListLine shoppingListLine)
        {
            if (id != shoppingListLine.ShoppingListLineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingListLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingListLineExists(shoppingListLine.ShoppingListLineID))
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
            return View(shoppingListLine);
        }

        // GET: ShoppingListLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingListLine = await _context.ShoppingListLine
                .FirstOrDefaultAsync(m => m.ShoppingListLineID == id);
            if (shoppingListLine == null)
            {
                return NotFound();
            }

            return View(shoppingListLine);
        }

        // POST: ShoppingListLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingListLine = await _context.ShoppingListLine.FindAsync(id);
            _context.ShoppingListLine.Remove(shoppingListLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingListLineExists(int id)
        {
            return _context.ShoppingListLine.Any(e => e.ShoppingListLineID == id);
        }
    }
}
