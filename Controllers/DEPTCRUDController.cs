using mvcproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcproject.Controllers
{
    [Authorize(Roles = "Admins")]
    public class DEPTCRUDController : Controller
    {
        // GET: DEPTCRUD
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Showdept()
        {
            List<department> dept = db.Departments.ToList();
            return View(dept);
        }
        public ActionResult adddept()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adddept(department d, HttpPostedFileBase imgpath)
        {
                string path = "~/imgfile/" + imgpath.FileName;
                imgpath.SaveAs(Server.MapPath(path));
                d.imgpath = imgpath.FileName;
                db.Departments.Add(d);
                db.SaveChanges();
                return RedirectToAction("Showdept");

        }

        public ActionResult removedept(int id)
        {
            department instr = db.Departments.Where(n => n.deptid == id).SingleOrDefault();
            db.Departments.Remove(instr);
            db.SaveChanges();
            return RedirectToAction("Showdept");
        }
        public ActionResult Editdept(int id)
        {
            department d = db.Departments.Find(id);
            return View(d);
        }

        [HttpPost]
        public ActionResult Editdept(department d)
        {
            department dept = db.Departments.Find(d.deptid);
            dept.deptname = d.deptname;
            dept.location = d.location;
            dept.imgpath = d.imgpath;
            db.SaveChanges();
            return RedirectToAction("Showdept");
        }
        public ActionResult viewemployees(int id)
        {
              List<employee> emp = db.Employees.Where(x=>x.deptid==id).ToList();
           // ViewBag.emp = db.Departments.Find(id);
         
            //ViewBag.emp = db.Employees.Find(id);
            return PartialView(emp);
        }

    }
}