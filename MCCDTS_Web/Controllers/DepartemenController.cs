using MCCDTS_Web.Context;
using MCCDTS_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MCCDTS_Web.Controllers
{
    public class DepartemenController : Controller
    {
        MyContext myContext;
        public DepartemenController(MyContext myContext)
        {
            this.myContext = myContext;
        }


        //READ
        public IActionResult Index()
        {
            var data = myContext.Departemens.ToList();
            return View(data);
        }
        //CREATE
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departemen departemen)
        {
            if (ModelState.IsValid)
            {
                myContext.Departemens.Add(departemen);
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
            var result = myContext.Departemens.Find(Id);
            return View(result);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departemen departemen)
        {
            if (ModelState.IsValid)
            {
                myContext.Departemens.Update(departemen);
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
            var result = myContext.Departemens.Find(Id);
            return View(result);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Departemen departemen)
        {
            if (ModelState.IsValid)
            {
                myContext.Departemens.Remove(departemen);
                var result = myContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int Id)
        {
            var result = myContext.Departemens.Find(Id);
            return View(result);
        }

    }
}
