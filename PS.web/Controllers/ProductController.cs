using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.Domain;
using PS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.web.Controllers
{
    public class ProductController : Controller
    {
        ProductService sp = new ProductService();
        CategoryService sc = new CategoryService();

        // GET: ProductController
        public ActionResult Index()
        {
            return View(sp.GetMany());
        }

        // POST: ProductController
        [HttpPost]
        public ActionResult Index(String filter)
        {
            return View(sp.GetMany(p=>p.Name.Contains(filter)));
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(sp.GetById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryFK = new SelectList(sc.GetMany(),"");

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection , IFormFile file)
        {
            try
            {
                sp.Add(collection);
                sp.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(sp.GetById(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection)
        {
            try
            {
                Product prod = sp.GetById(id);
                prod = collection;
                sp.Update(prod);
                sp.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sp.GetById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
                
                sp.Delete(sp.GetById(id));
                sp.Commit();
                return RedirectToAction(nameof(Index));
           
        }
    }
}
