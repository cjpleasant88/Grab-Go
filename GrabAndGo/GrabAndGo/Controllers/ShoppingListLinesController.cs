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

                var list = (from aisle in _context.Aisle
                           where aisle.StoreID == user.StorePref && aisle.CategoryID == product.CategoryID
                           select new { aisle.AisleNumber }).ToList();

                if (line == null)
                {
                    _context.ShoppingListLine.Add(new ShoppingListLine
                    {
                        ListID = user.ListID,
                        ProductID = ProductID,
                        ProductName = product.ProductName,
                        Quantity = 1
                    }); ;
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


            //Below is Main Logic to grab users list, join with other tables to filter out by store and order by Aisle numbers
            //TODO: Add sections in the future for even easier store navigation (as in which section of the aisle the product is in)

            //Get the aisles in the Users Store preference
            var storePrefAisles = _context.Aisle.Where(aisle => aisle.StoreID == user.StorePref).Select(aisle => aisle);

            List<ShoppingList> orderedList = (from listLine in _context.ShoppingListLine
                                where listLine.ListID == user.ListID
                                join product in _context.Product on listLine.ProductID equals product.ProductID                     //Joins users list with productDB to get category ID
                                join category in _context.Category on product.CategoryID equals category.CategoryID                 //Joins previous with CategoryDB to get category name
                                join aisle in storePrefAisles on category.CategoryID equals aisle.CategoryID into userList          //Left Joins previous with aisles in store
                                from eachline in userList.DefaultIfEmpty()                                                          //if product is not in store, AisleNumber defaulst to 0
                                orderby eachline.AisleNumber                                                                        //Orders by Aisle numbers
                                select new ShoppingList                                                                             //Creates a new ShoppingList View Model to pass into the list
                                {
                                    ProductName = listLine.ProductName,
                                    Quantity = listLine.Quantity,
                                    AisleNumber = eachline.AisleNumber,// > 0 ? eachline.AisleNumber : -1,
                                    Category = category.CategoryName,
                                }).ToList();

            //Retrieves the Store Name to Pass the View
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
                return RedirectToAction("ShoppingList", new { userName = User.Identity.Name });

            }

            Response.StatusCode = 404;
            return RedirectToAction("HttpsStatusCodeHandler", "Error", new { statusCode = 123 });

        }
    }
}
