﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using MCCDTS_Web.Models;
using MCCDTS_Web.Context;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCCDTS_Web.Controllers
{
    public class EmployeeController : Controller
    {
        MyContext myContext;
        public EmployeeController(MyContext myContext)
        {
            this.myContext = myContext;
        }


        //READ
        public IActionResult Index()
        {
            var data = myContext.Employees.ToList();
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
        public IActionResult Create(Employee karyawan)
        {
            if (ModelState.IsValid)
            {
                myContext.Employees.Add(karyawan);
                var result = myContext.SaveChanges();
                if (result > 0)
                return RedirectToAction("Index");
            }
            return View();
        }
        //UPDATE
        //GET
        public IActionResult Edit(int Id)
        {
            var data = myContext.Employees.Find(Id);
            ViewBag.DepartmentId = new SelectList(myContext.Departemens, "Id", "Id", data.DepartemenId);
            return View(data);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, Employee karyawan)
        {
            if (ModelState.IsValid)
            {
                myContext.Employees.Update(karyawan);
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
            var data = myContext.Employees.Find(Id);
            return View(data);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee karyawan)
        {
            if (ModelState.IsValid)
            {
                myContext.Employees.Remove(karyawan);
                var result = myContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var data = myContext.Employees.Find(Id);
            return View(data);
        }

    }
}


