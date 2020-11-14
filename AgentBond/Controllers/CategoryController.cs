using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentBond.Data;
using AgentBond.Migrations;
using AgentBond.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgentBond.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        //This has an instance of the DbContext that DI will create and pass in constructor
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<AgentBond.Models.Category> objList = _db.Category;
            return View(objList);
        }
        //GEt -> CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST -> CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AgentBond.Models.Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET -> EDIT
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST -> EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AgentBond.Models.Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET -> DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST -> DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Category.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           
        }
    }
}
