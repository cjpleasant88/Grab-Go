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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
//using AspNetCore;
using GrabAndGo.Models.ViewModels;
using System.Composition;
using SQLitePCL;

namespace GrabAndGo.Controllers
{
    //Must be a member of either Admin or User Role or both
    [Authorize(Roles = "Admin, User")]
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

            if (user == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("HttpsStatusCodeHandler", "Error", new { statusCode = 123 });
            }

            if (user.RequestToShare == true)
            {
                var sharingUser = await _userManager.FindByIdAsync(user.SharedListId);
                return RedirectToAction("ShareRequest", new {email = sharingUser.UserName });
            }
            ViewBag.IsSharing = user.IsSharing;
            return View(_context.ShoppingListLine.Where(p => p.ListID.Equals(user.ListID)));
        }

        public IActionResult ShareRequest(string email)
        {
            ViewBag.SharingUser = email;
            return View();
        }

        public async Task<IActionResult> ShareAccept()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.ListID = user.SharedListId;
            user.IsSharing = true;
            user.RequestToShare = false;

            var result = await _userManager.UpdateAsync(user);

            return RedirectToAction("YourList", new { userName = user.UserName });
        }

        public async Task<IActionResult> ShareDeny()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.RequestToShare = false;

            var result = await _userManager.UpdateAsync(user);

            return RedirectToAction("YourList", new { userName = user.UserName });
        }

        public async Task<IActionResult> StopSharing()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.ListID = user.Id;
            user.IsSharing = false;
            user.RequestToShare = false;

            var result = await _userManager.UpdateAsync(user);

            return RedirectToAction("YourList", new { userName = user.UserName });
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

        public async Task<IActionResult> ShoppingList(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("HttpsStatusCodeHandler", "Error", new { statusCode = 123 });
            }

            //List<ShoppingListLine> list = _context.ShoppingListLine.Where(p => p.ListID.Equals(user.ListID)).ToList();

            //var join = from pid in _context.Product
            //           join cat in _context.Category on pid.CategoryID equals cat.CategoryID
            //           where pid.ProductID == ProductID
            //           select new { name = pid.ProductName, id = pid.ProductID };

            //string name = join.FirstOrDefault(line => line.id == ProductID).name;

            //var join = from listLine in _context.ShoppingListLine
            // join category in _context.Category 


            //Main Logic to grab users list, join with other tables to filter out by store and order by Aisle numbers
            //TODO: Add sections in the future for even easier store navigation (as in which section of the aisle the product is in)

            List<ShoppingList> orderedList = (from listLine in _context.ShoppingListLine where listLine.ListID == user.ListID
                                              join product in _context.Product on listLine.ProductID equals product.ProductID
                                              join category in _context.Category on product.CategoryID equals category.CategoryID
                                              join aisle in _context.Aisle on category.CategoryID equals aisle.CategoryID where aisle.StoreID == user.StorePref
                                              orderby aisle.AisleNumber
                                              select new ShoppingList { ProductName = listLine.ProductName, Quantity = listLine.Quantity, AisleNumber = aisle.AisleNumber, Category = category.CategoryName }).ToList();

            //List<ShoppingList> orderedList2 = (from aisle in _context.Aisle
            //                                      join category in _context.Category on aisle.CategoryID equals category.CategoryID
            //                                      join product in _context.Product on category.CategoryID equals product.CategoryID
            //                                      join listLine in _context.ShoppingListLine on product.ProductID equals listLine.ProductID
            //                                      where listLine.ListID == user.ListID && aisle.StoreID == user.StorePref
            //                                      orderby aisle.AisleNumber
            //                                      select new ShoppingList { ProductName = listLine.ProductName, Quantity = listLine.Quantity, AisleNumber = aisle.AisleNumber, Category = category.CategoryName }).ToList();

            string StoreName = (from store in _context.Store
                                where store.StoreID == user.StorePref
                                select new { name = store.StoreName, id = store.StoreID})
                                .ToList()
                                .FirstOrDefault(store => store.id == user.StorePref).name;

            ViewBag.StoreName = StoreName;
            return View(orderedList);
        }

        [HttpGet]
        public IActionResult ShareList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShareList(SharedUser model)
        {
            var thisUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var sharedUser = await _userManager.FindByNameAsync(model.SharedUserEmail);

            if (sharedUser == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("HttpsStatusCodeHandler", "Error", new { statusCode = 123 });
            }

            sharedUser.SharedListId = thisUser.ListID;
            sharedUser.RequestToShare = true;

            var result = await _userManager.UpdateAsync(sharedUser);

            if (result.Succeeded)
            {
                return RedirectToAction("SharingSuccess", new { Email = sharedUser.Email});
            }
   
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        public IActionResult SharingSuccess(string Email)
        {
            ViewBag.Shared = Email;
            return View();
        }




        public async Task<IActionResult> ChangeStoreList()
        {
            return View(await _context.Store.ToListAsync());
        }

        public async Task<IActionResult> ChangeStorePreference(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.StorePref = id;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("YourList", new { userName = User.Identity.Name });

            }

            Response.StatusCode = 404;
            return RedirectToAction("HttpsStatusCodeHandler", "Error", new { statusCode = 123 });

        }
    }
}
