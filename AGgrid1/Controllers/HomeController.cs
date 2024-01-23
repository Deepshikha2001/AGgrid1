using AGgrid1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AGgrid1.Controllers
{

    public class HomeController : Controller
    {
        private readonly ProductDbContext1 context;
        public HomeController(ProductDbContext1 context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Prod()
        {
            var result = context.Products.OrderBy(x => x.Id).ToList();
            return Json(result);
        }


        [HttpPost]
        public IActionResult Create(Product1 model)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit([FromBody] Product1 editedProduct)
        {


            if (editedProduct != null)
            {

                context.Products.Update(editedProduct);
                context.SaveChanges();

            }
            return RedirectToAction("Index");

        }



        public IActionResult Destroy(int? id)
        {
            if (id != null)
            {
                var product = context.Products.Find(id);
              
                    context.Products.Remove(product);
                    context.SaveChanges();
                
            }
            var remproduct = context.Products.OrderBy(x => x.Id == id).ToList();
            return Json(remproduct);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

