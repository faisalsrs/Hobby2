using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltExam3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BeltExam3.Controllers
{
    public class HomeController : Controller
    {
        private int? UserSession
        {
            get { return (int?)HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }
        private Context DbContext;
        public HomeController(Context context)
        {
            DbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("User/new")]
        public IActionResult registration(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (DbContext.Users.FirstOrDefault(q => q.username == newUser.username) != null)
                {
                    ModelState.AddModelError("username", "Please log in");
                    return View("Index");
                }
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.password = hasher.HashPassword(newUser, newUser.password);
                DbContext.Add(newUser);
                DbContext.SaveChanges();
                UserSession = newUser.UserId;
                return RedirectToAction("success");
            }
            return View("Index");
        }
        [HttpPost("User/login")]
        public IActionResult login(Login user)
        {
            if (ModelState.IsValid)
            {
                User userInDb = DbContext.Users.FirstOrDefault(p => p.username == user.lusername);
                if (userInDb == null)
                {
                    ModelState.AddModelError("lusername", "Invalid Username/Password");
                    return View("Index");
                }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(user, userInDb.password, user.lpassword);
                if (result == 0)
                {
                    ModelState.AddModelError("lpassword", "Invalid Username/Password");
                    return View("Index");
                }
                else
                {
                    UserSession = userInDb.UserId;
                    return RedirectToAction("success");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("User/success")]
        public IActionResult success()
        {
            if (UserSession == null)

            {
                return RedirectToAction("Index");
            }
            User user = DbContext.Users.FirstOrDefault(q => q.UserId == UserSession);
            List<Hobby> allH = DbContext.Hobbies.Include(w => w.CreatedJOINs).Include(q => q.Creator).ToList();
            successModel model = new successModel();
            model.userLogged = user;
            model.allH = allH;
            return View(model);
        }

        [HttpGet("createhobby")]
        public IActionResult createhobby()
        {
            return View("createhobby");
        }
        [HttpPost("Hobby/new")]
        public IActionResult addhobby(Hobby newHobby)
        {
            if (UserSession == null)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                bool nameinDB = DbContext.Hobbies.Any(q => q.Name == newHobby.Name);
                if (nameinDB == true)
                {
                    ModelState.AddModelError("name", "Hobby Already Exist, Please try another");

                    return View("createhobby");
                }

                newHobby.UserId = (int)UserSession;
                DbContext.Hobbies.Add(newHobby);
                DbContext.SaveChanges();
                return RedirectToAction("success");
            }
            TempData["errors"] = "Activity and Description cannot be empty";
            return View("createhobby");
        }

        [HttpGet("OneHobby/{HobbyId}")]
        public IActionResult OneHobby(int HobbyId)
        {
            if (UserSession == null)
            {
                return RedirectToAction("Index");
            }
            Hobby onehobby = DbContext.Hobbies.Include(w => w.CreatedJOINs).ThenInclude(r => r.UserJOIN).FirstOrDefault(w => w.HobbyId == HobbyId); //take one wedding and include all the information from the RSVP list and in that information I also want user information. 
            ViewBag.user = UserSession;
            return View(onehobby);
        }
        [HttpPost("GoingtoHobby/{HobbyId}")]
        public IActionResult Join(int HobbyId)
        {
            if (UserSession == null)
            {
                return RedirectToAction("Index");
            }
            JOIN going = new JOIN();
            going.HobbyId = HobbyId;
            going.UserId = (int)UserSession;
            DbContext.Join.Add(going);
            DbContext.SaveChanges();
            return RedirectToAction("success");
        }

        [HttpGet("Hobby/edit/{HobbyId}")]
        public IActionResult edit(int HobbyId)
        {
            Hobby HobbyToEdit = DbContext.Hobbies.FirstOrDefault(q => q.HobbyId == HobbyId);
            return View(HobbyToEdit);
        }


        [HttpPost("Hobby/edit/{HobbyId}")]
        public IActionResult update(Hobby updated, int HobbyId)
        {
            if (ModelState.IsValid)
            {
                Hobby HobbyfromDb = DbContext.Hobbies.FirstOrDefault(q => q.HobbyId == HobbyId);
                HobbyfromDb.Name = updated.Name;
                HobbyfromDb.Description = updated.Description;
                DbContext.SaveChanges();
                return RedirectToAction("success");
            }
            return View("edit", updated);
        }
        [HttpGet("Home/logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

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
