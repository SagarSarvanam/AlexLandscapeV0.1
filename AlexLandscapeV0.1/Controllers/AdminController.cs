using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexLandscapeV0._1.Models;
using AlexLandscapeV0._1.RepositoryLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AlexLandscapeV0._1.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository iad;
        public AdminController(IAdminRepository _iad)
        {
            iad = _iad;
        }

        public IActionResult Index()
        {
            Admin ad = new Admin();
            if (ad == null)
            {
                return View(ad);
            }
            else
            {
                return View(ad);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind] string username, string password)
        {
            if (username != null && password != null)
            {
                var _data = iad.Login(username, password);
                if(_data != null)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
                
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
