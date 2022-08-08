using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Network.Db_Context;
using Network.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Network.Controllers
{
    public class NetworkController : Controller
    {
        private readonly ILogger<NetworkController> _logger;

        private readonly IWebHostEnvironment environment;

        public NetworkController(IWebHostEnvironment environment)
        {

            this.environment = environment;
        }

        public IActionResult Image()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        NetworkContext obj1 = new NetworkContext();
        private IFormFile FilePath;

        //-------Cascading dropdwon-----
        //public JsonResult Country()
        //{
        //    var cnt = obj1.Countries.ToList();
        //    return new JsonResult(cnt);
        //}

        //public JsonResult State(int id)

        //{
        //    var st = obj1.States.Where(e => e.Country.Id == id).ToList();
        //    return new JsonResult(st);
        //}

        //public JsonResult City(int id)
        //{
        //    var ct = obj1.Cities.Where(e => e.State.Id == id).ToList();

        //    return new JsonResult(ct);
        //}

       
        public IActionResult RegTable1()
        {
            NetworkContext obj = new NetworkContext();
            var res = obj.Users.ToList();
            var NameR = HttpContext.Session.GetString("Temp1");
            ViewBag.Name = NameR;
            var y = HttpContext.Session.GetString("Temp");
            var z = obj.Users.Where(m => m.AdminReferCode == y).ToList();

            List<UserModel> Ab = new List<UserModel>();
            foreach (var item in z)
            {

                Ab.Add(new UserModel
                {

                    Id = item.Id,
                    Name = item.Name,
                    UserName = item.UserName,
                    EmailId = item.EmailId,
                    Password = item.Password,
                    AddharNo = item.AddharNo,
                    CreateRefer = item.CreateRefer,
                    PhoneNo = item.PhoneNo,
                    Gender = item.Gender,
                    Amount = item.Amount,
                    AdminReferCode = item.AdminReferCode,
                    Country = item.Country,
                    State = item.State,
                    City = item.City,
                    Title = item.Title,
                    FilePath = item.ImageData

                });
            }

                return View(Ab);
        }

        //-------------------------------------------------------------------------------------------------------------------------
          
        public IActionResult RegTable()
        {
            int p = 0;
            int ide = 3;
            var r = 0;
            int level = 1;
            //int level_1 = 0;
            //int level_2 = 1000;
            //int level_3 = 500;
            //int level_4 = 3500;
            //int level_5 = 1500;
            //int level_6 = 3500;
            //int level_7 = 5000;
            //int level_8 = 1500;
            //int level_9 = 0;
            //int level_10 = 0;

            int bonus = 0;
            int rec = 0;
            NetworkContext obj = new NetworkContext();
            var res = obj.Users.ToList();
            var NameR = HttpContext.Session.GetString("Temp1");
            ViewBag.Name = NameR;
            var image = HttpContext.Session.GetString("Temp2");
            ViewBag.image = image;
            var y = HttpContext.Session.GetString("Temp");
            var z = obj.Users.Where(m => m.AdminReferCode == y).ToList();

            List<UserModel> Ab = new List<UserModel>();
            foreach (var item in z)
            {
              
                Ab.Add(new UserModel
                {

                    Id = item.Id,
                    Name = item.Name,
                    UserName = item.UserName,
                    EmailId = item.EmailId,
                    Password = item.Password,
                    AddharNo = item.AddharNo,
                    CreateRefer = item.CreateRefer,
                    PhoneNo = item.PhoneNo,
                    Gender = item.Gender,
                    Amount = item.Amount,
                    AdminReferCode = item.AdminReferCode,
                    Country = item.Country,
                    State = item.State,
                    City = item.City,
                    Title = item.Title,
                    FilePath =item.ImageData

                });

                r = z.Count;
                ViewBag.re = r;
            }
            for (int i = 1; i <= r; i++)
            {
                rec = i;
                if (rec <= 20)
                {
                    if (rec == ide)
                    {
                        p = p + 1000;
                    }
                    else
                    {
                        p = p + 500;
                    }
                    if (rec == ide)
                    {
                        ide = ide + 3;
                    }
                    else
                    {

                    }
                    if (rec == 10)
                    {
                        p = p + 500;
                    }
                }
                else
                {
                    p = p + 500;
                }


                if (rec < 10)
                {
                    level = 1;
                    ViewBag.level = level;
                    bonus = 0;
                 
                }
                else if (rec >= 10 && rec < 20)
                {
                    if(rec==10)
                    {
                        ViewBag.level = level;
                        bonus = 1000;
                    }
                    level = 2;
                    ViewBag.level = level;
                 
                    
                }

                else if ((rec >= 20) && (rec < 40))
                {
                    if(rec==20)
                    {
                        level = 3;
                        ViewBag.level = level;
                        bonus = bonus + 500;
                        p = p + 500;
                    }
                    level = 3;
                    ViewBag.level = level;
                  
                }

                else if ((rec >= 40) && (rec < 50))
                {
                    if(rec==40)
                    {
                        level = 4;
                        ViewBag.level = level;
                        bonus = bonus + 3500;
                        p = p + 3500;
                    }
                    level = 4;
                    ViewBag.level = level;

                }

                else if (rec >=50 && rec<70)
                {
                    if (rec == 50)
                    {
                        level = 5;
                        ViewBag.level = level;
                        bonus = bonus + 1500;
                        p = p + 1500;
                    }
                    level = 5;
                    ViewBag.level = level;
                                  
                }

                else if ((rec >= 70) && (rec < 100))
                {
                    if (rec == 70)
                    {
                        level = 6;
                        ViewBag.level = level;
                        bonus = bonus + 3500;
                        p = p + 3500;

                    }
                    level = 6;
                    ViewBag.level = level;

                }

                else if ((rec >= 100) && (rec < 110))
                {
                    if (rec == 100)
                    {
                        level = 7;
                        ViewBag.level = level;
                        bonus = bonus + 5000;
                        p = p + 5000;
                    }
                    level = 7;
                    ViewBag.level = level;
                }

                else
                {
                    if (rec == 110)
                    {
                        level = 8;
                        ViewBag.level = level;
                        bonus = bonus + 1500;
                        p = p + 1500;
                    }
                    level = 8;
                    ViewBag.level = level;
                 
                }
            }
            ViewBag.bonus = bonus;
            ViewBag.sal = p;

            return View(Ab);

        }

        public IActionResult Edit(int Id)
        {
            NetworkContext obj = new NetworkContext();
            UserModel Ab = new UserModel();
            var db = obj.Users.ToList();

            var A = HttpContext.Session.GetString("Temp");

            var res = obj.Users.Where(m => m.CreateRefer == A).First();
            Ab.Id = res.Id;
            Ab.Name = res.Name;
            Ab.UserName = res.UserName;
            Ab.EmailId = res.EmailId;
            Ab.Password = res.Password;
            Ab.AddharNo = res.AddharNo;
            Ab.CreateRefer = res.CreateRefer;
            Ab.PhoneNo = res.PhoneNo;
            Ab.Gender = res.Gender;
            Ab.Amount = res.Amount;
            Ab.AdminReferCode = res.AdminReferCode;
            Ab.Country = res.Country;
            Ab.State = res.State;
            Ab.City = res.City;
            Ab.Title = res.Title;
            Ab.FilePath = res.ImageData;


            //TempData["temp"] = res.Id;
            return View("Registration",Ab);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            var p = Convert.ToString(HttpContext.Session.GetString("Temp"));
            ViewBag.Massege = p;
            return View();

        }

        [HttpPost]
        public IActionResult Registration(UserModel As)
        {
            if (ModelState.IsValid)
            {


                var path = environment.WebRootPath;

                var filePate = "Content/Image/" + As.ImageData.FileName;
                var fullPath = Path.Combine(path, filePate);
                UplodeFile(As.ImageData, fullPath);

                NetworkContext obj = new NetworkContext();

                User ob = new User();
                var emailadd = (from x in obj.Users where x.EmailId == As.EmailId select x).FirstOrDefault();
                if (As.Id == 0)
                {
                    if (emailadd != null)
                    {
                        ViewBag.Message = "email id already exist";
                        return View();
                    }
                    else
                    {
                        ob.Id = As.Id;
                        ob.Name = As.Name;
                        ob.UserName = As.UserName;
                        ob.EmailId = As.EmailId;
                        ob.Password = As.Password;
                        ob.AddharNo = As.AddharNo;
                        ob.CreateRefer = As.CreateRefer;
                        ob.PhoneNo = As.PhoneNo;
                        ob.Gender = As.Gender;
                        ob.Amount = As.Amount;
                        ob.AdminReferCode = As.AdminReferCode;
                        ob.Country = As.Country;
                        ob.State = As.State;
                        ob.City = As.City;
                        ob.Title = As.Title;
                        ob.ImageData = filePate;

                        obj.Users.Add(ob);
                        obj.SaveChanges();
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    ob.Id = As.Id;
                    ob.Name = As.Name;
                    ob.UserName = As.UserName;
                    ob.EmailId = As.EmailId;
                    ob.Password = As.Password;
                    ob.AddharNo = As.AddharNo;
                    ob.CreateRefer = As.CreateRefer;
                    ob.PhoneNo = As.PhoneNo;
                    ob.Gender = As.Gender;
                    ob.Amount = As.Amount;
                    ob.AdminReferCode = As.AdminReferCode;
                    ob.Country = As.Country;
                    ob.State = As.State;
                    ob.City = As.City;
                    ob.Title = As.Title;
                    ob.ImageData = filePate;

                    obj.Entry(ob).State = EntityState.Modified;
                    obj.SaveChanges();
                    return RedirectToAction("RegTable");
                }

            }


            return View();
        }

        public void UplodeFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(UserModel Ab)
        {

            NetworkContext obj = new NetworkContext();
            var obj1 = obj.Users.ToList();
            var res = obj.Users.Where(m => m.EmailId == Ab.EmailId).FirstOrDefault();
            if (res != null)
            {
                var x = obj.Users.Where(m => m.AdminReferCode == res.CreateRefer).ToList();

                HttpContext.Session.SetString("Temp", res.CreateRefer.ToString());
                var y = HttpContext.Session.GetString("Temp");

                HttpContext.Session.SetString("Temp1", res.Name.ToString());
                var NameR = HttpContext.Session.GetString("Temp1");

                HttpContext.Session.SetString("Temp2", res.ImageData.ToString());
                var image = HttpContext.Session.GetString("Temp2");
            }
            else
            {

            }
            if (res == null)
            {
                TempData["invalid"] = "email is not found";
            }
            else
            {
                if (res.EmailId == Ab.EmailId && res.Password == Ab.Password)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, res.Name),
                                        new Claim(ClaimTypes.Email, res.EmailId) };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };
                    HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    authProperties);
                    return RedirectToAction("RegTable", "Network");

                }

                else
                {
                    ViewBag.Inv = "Wrong Email Id or password";

                    return View("Login");
                }

            }

            return View();

        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            return RedirectToAction("Login", "Network");
            
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
