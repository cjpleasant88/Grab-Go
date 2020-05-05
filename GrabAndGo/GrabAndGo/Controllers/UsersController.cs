using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrabAndGo.Data;
using GrabAndGo.Models;
using System.Security.Cryptography;
using System.Text;

namespace GrabAndGo.Controllers
{
    public class UsersController : Controller
    {
        private readonly GrabAndGoContext _context;

        public UsersController(GrabAndGoContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }


        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,FirstName,LastName,Email,Password,ListID,ListName,StorePref")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Encrypt(user.Password);
                if (user.ListName == null)
                {
                    user.ListName = user.FirstName + "'s List";
                }
                _context.Add(user);
                await _context.SaveChangesAsync();

                var newuser = await _context.User.FirstOrDefaultAsync(m => m.Email == user.Email).ConfigureAwait(false);
                newuser.ListID = newuser.UserID;
                _context.Update(newuser);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,FirstName,LastName,Email,Password,ListID,ListName,StorePref")] User user)
        {
            //if (id != user.UserID)
            //{
            //    return RedirectToAction("DoesNotExist");
            //    //return NotFound();
            //}

            //var updatedUser = await _context.User.FirstOrDefaultAsync(m => m.UserID == user.UserID).ConfigureAwait(false);
            var updatedUser = await _context.User.FindAsync(id);
            if (ModelState.IsValid)
            {
                try
                {
                    updatedUser.FirstName = user.FirstName;
                    updatedUser.LastName = user.LastName;
                    updatedUser.Email = user.Email;
                    updatedUser.Password = Encrypt(user.Password);
                    updatedUser.ListName = user.ListName;
                    updatedUser.StorePref = user.StorePref;
                    updatedUser.ListID = updatedUser.UserID;

                    _context.Update(updatedUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        //public IActionResult List(LoginViewModel login)
        //{
        //    var user = _context.User.FirstOrDefault(u => u.Email == login.Email);

        //    if (user == null)
        //    {
        //        return RedirectToAction("DoesNotExist");
        //    }
        //    else
        //    {
        //        if (login.Password == user.Password)
        //        {
        //            return RedirectToAction("List", "Home");
        //        }
        //        else
        //        {
        //            return RedirectToAction("IncorrectPassword");
        //        }
        //        //return $"Email: {login.Email} and PW: {Encrypt(user.Password)} from the user list View, Will return the list for this user";
        //    }
        //}

        public IActionResult DoesNotExist()
        {
            return View();
        }

        public IActionResult IncorrectPassword()
        {
            return View();
        }

        public static string Encrypt(string input)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 algo = MD5.Create())
            {
                byte[] data = algo.ComputeHash(Encoding.UTF8.GetBytes(input));
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }
            return sBuilder.ToString();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult List([Bind("Email,Password")] LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                //var user = await _context.User.FirstOrDefault(u => u.Email == login.Email);


                var user = _context.User.FirstOrDefault(u => u.Email == login.Email);

                //var user = await _context.User.FindAsync(login.Email);
                //if (user == null)
                //{
                //    RedirectToAction("DoesNotExist")
                //    //return NotFound();
                //}

                if (user == null)
                {
                    return RedirectToAction("DoesNotExist");
                }
                else
                {
                    if (Encrypt(login.Password) == user.Password)
                    {
                        return RedirectToAction("List", "Home");
                    }
                    else
                    {
                        return RedirectToAction("IncorrectPassword");
                    }
                    //return $"Email: {login.Email} and PW: {Encrypt(user.Password)} from the user list View, Will return the list for this user";
                }
            }
            //return View(login);
            return RedirectToAction("HomePage", "Home", login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult List2([Bind("Email,Password")] LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                //var user = await _context.User.FirstOrDefault(u => u.Email == login.Email);


                var user = _context.User.FirstOrDefault(u => u.Email == login.Email);

                //var user = await _context.User.FindAsync(login.Email);
                //if (user == null)
                //{
                //    RedirectToAction("DoesNotExist")
                //    //return NotFound();
                //}

                if (user == null)
                {
                    return RedirectToAction("DoesNotExist");
                }
                else
                {
                    if (Encrypt(login.Password) == user.Password)
                    {

                        return RedirectToAction("List2", "Home", new { listID = user.ListID});
                    }
                    else
                    {
                        return RedirectToAction("IncorrectPassword");
                    }
                    //return $"Email: {login.Email} and PW: {Encrypt(user.Password)} from the user list View, Will return the list for this user";
                }
            }
            //return View(login);
            return RedirectToAction("HomePage", "Home", login);
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserID == id);
        }
    }
}
