using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Model;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly GoodsContext db;


        public LoginController(GoodsContext _db)
        {
            db = _db;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(UserTable u)
        {
            
            UserTable result = (from i in db.UserTables where i.UserId==u.UserId && i.Password == u.Password select i).FirstOrDefault(); 
            if(result!= null)
            {
                string UserName = result.UserName;
                HttpContext.Session.SetString("UserName", UserName);
                return RedirectToAction("Index","Org");
            }
            else
                return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
