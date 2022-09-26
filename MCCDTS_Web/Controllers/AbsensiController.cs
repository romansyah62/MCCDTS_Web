using MCCDTS_Web.Context;
using MCCDTS_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MCCDTS_Web.Controllers
{
    public class AbsensiController : Controller
    {
        MyContext myContext;
        public AbsensiController(MyContext myContext)
        {
            this.myContext = myContext;
        }


        //READ
        public IActionResult Index()
        {
            var data = myContext.Absensis.Include(x => x.Employee).Include(y => y.Employee.Departemen).ToList();
            return View(data);
        }
        //CREATE
        //GET
        public IActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(myContext.Employees, "Id", "Id");
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Absensi absensi)
        {
            if (ModelState.IsValid)
            {
                myContext.Absensis.Add(absensi);
                var result = myContext.SaveChanges();
                if (result != 0)
                    return RedirectToAction("Index");
            }
            return View();
        }
        //UPDATE
        //GET
        public IActionResult Edit(int Id)
        {
            var result = myContext.Absensis.Find(Id);
            ViewBag.EmployeeId = new SelectList(myContext.Employees, "Id", "Id", result.EmployeeId);
            return View(result);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Absensi absensi)
        {
            if (ModelState.IsValid)
            {
                myContext.Absensis.Update(absensi);
                var result = myContext.SaveChanges();
                if (result != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }



        //DELETE
        //GET
        public IActionResult Delete(int Id)
        {
            var result = myContext.Absensis.Find(Id);
            return View(result);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Absensi absensi)
        {
            if (ModelState.IsValid)
            {
                myContext.Absensis.Remove(absensi);
                var result = myContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int Id)
        {
            var result = myContext.Absensis.Find(Id);
            return View(result);
        }
    }
}
