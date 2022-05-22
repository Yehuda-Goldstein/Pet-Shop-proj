using AspWebProj.Data;
using AspWebProj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace AspWebProj.Controllers
{
    public class CatalogController : Controller
    {
        public PetShopContext Context { get; }
        public CatalogController(PetShopContext context)
        {
            Context = context;
        }
        public IActionResult CatalogPage(int id)
        {
            if (id == 0)
            {
                id = 1;
            }
            ICollection<Animal> animals = Context.Pets.Where(animal => animal.CategoryId == id).ToList();
            ViewBag.id = id;
            ViewBag.animals = animals;
            IEnumerable<Category> categories = Context.Categories.ToList();
            return View(categories);
        }
    }
}