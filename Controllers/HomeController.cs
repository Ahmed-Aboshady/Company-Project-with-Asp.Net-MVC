using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject.Models;

namespace mvcproject.Controllers
{
    [Authorize(Roles = "emplyees")]
    
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<department> dept = db.Departments.ToList();
            return View(dept);
        }
        public ActionResult register()
        {
            List<department> dept = db.Departments.ToList();
            SelectList deptlist = new SelectList(dept, "deptid", "deptname ");
            ViewBag.dept = deptlist;
            return View();
        }
        [HttpPost]
        public ActionResult register(employee em, HttpPostedFileBase imgpath, HttpPostedFileBase filpath)
        {
            if (ModelState.IsValid)
            {
                string path = "~/imgfile/" + imgpath.FileName;
                string pathfile = "~/imgfile/" + filpath.FileName;
                imgpath.SaveAs(Server.MapPath(path));
                filpath.SaveAs(Server.MapPath(pathfile));
                em.imgpath = imgpath.FileName;
                em.cvpath = filpath.FileName;
                db.Employees.Add(em);
                db.SaveChanges();
                return RedirectToAction("index");

            }
            else
            {
                List<department> dept = db.Departments.ToList();
                SelectList deptlist = new SelectList(dept, "deptid", "deptname");
                ViewBag.dept = deptlist;
                return View();
            }
        }

        public ActionResult employee(int id)
        {
            
            List<employee> emp = db.Employees.Where(x=>x.deptid==id).ToList();
            return View(emp);
        }
        [Authorize(Roles = "Admins")]
        public ActionResult remove(int id)
        {
            employee emp = db.Employees.Where(n => n.id == id).SingleOrDefault();
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [Authorize(Roles = "Admins")]
        public ActionResult edit(int id)
        {
            employee emp = db.Employees.Find(id);
            List<department> depts = db.Departments.ToList();
            ViewBag.dept = new SelectList(depts, "deptid", "deptname", emp.deptid);

            return View(emp);
        }
        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult edit(employee emp)
        {
            
            employee ee = db.Employees.Find(emp.id);
            ee.name = emp.name;
            ee.salary = emp.salary;
            ee.emali = emp.emali;
            ee.deptid = emp.deptid;
            ee.password = emp.password;
            ee.confirmpassword = emp.confirmpassword;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult viewajax(int id)
        {
            ViewBag.emp = db.Employees.Find(id);
            return PartialView();
        }
    }
}