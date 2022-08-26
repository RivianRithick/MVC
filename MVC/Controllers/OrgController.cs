using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Model;

namespace MVC.Controllers
{
    public class OrgController : Controller
    {
        private readonly GoodsContext db;
        public OrgController(GoodsContext _db)
        {
            db = _db;
        }
        //[HttpGet]
        //public IActionResult SuppIndex()
        //{
        //    /*ar result = db.Suppliers.Include(x => x.Products).ToList();*/
        //    return View();
        //}
        public IActionResult Direct()
        {
            return View();
        }
        public IActionResult Slist()
        {
            return View(db.Suppliers.ToList());
        }
        [HttpGet]
        public IActionResult Createsup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Createsup(Supplier s)
        {
            db.Suppliers.Add(s);
            db.SaveChanges();
            return RedirectToAction("Slist");
        }
        [HttpGet]
        public IActionResult SuppDetails(int id)
        {
            Supplier r = db.Suppliers.Find(id);
            return View(r);
        }
        public IActionResult SuppEdit(int id)
        {
            //var result = new SelectList(from i in db.Suppliers
            //                            select i.Sid).ToList();
            //ViewBag.Sid = result;
            Supplier r = db.Suppliers.Find(id);
            return View(r);
        }
        [HttpPost]
        public IActionResult SuppEdit(Supplier r)
        {
            //Red r1=new Red();
            //r1 = r;
            db.Suppliers.Update(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SuppDelete(int id)
        {
            Supplier r = db.Suppliers.Find(id);
            return View(r);
        }
        [HttpPost]
        // [ActionName("Delete")]
        public IActionResult SuppDelete(Supplier r)
        {
            db.Suppliers.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    

    //---------------------------------------------------------------------------------------------//
    public IActionResult List(int id)
        {

            List<Product> result = (from i in db.Products.Include(x => x.SidNavigation)
                                where i.Sid == id
                                select i).ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            if (ViewBag.UserName != null)
            {

                var result = db.Products.Include(x => x.SidNavigation).ToList();
                return View(result);
            }
            else;
            {
                return RedirectToAction("login", "Login");
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            var result = new SelectList(from i in db.Suppliers
                                        select i.Sid).ToList();
            ViewBag.Sid = result;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Product r = db.Products.Find(id);
            return View(r);
        }
        public IActionResult Edit(int id)
        {
            var result = new SelectList(from i in db.Suppliers
                                        select i.Sid).ToList();
            ViewBag.Sid = result;
            Product r = db.Products.Find(id);
            return View(r);
        }
        [HttpPost]
        public IActionResult Edit(Product r)
        {
            //Red r1=new Red();
            //r1 = r;
            db.Products.Update(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Product r = db.Products.Find(id);
            return View(r);
        }
        [HttpPost]
        // [ActionName("Delete")]
        public IActionResult Delete(Product r)
        {
            db.Products.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }


}

