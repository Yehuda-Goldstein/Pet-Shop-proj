using Microsoft.AspNetCore.Mvc;
using AspWebProj.Data;
using AspWebProj.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspWebProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly PetShopContext _context;
        public HomeController(PetShopContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            var comment = _context.Comments.ToList();
            IQueryable<Animal> TwoBestAnimals = _context.Pets.OrderBy(animal => animal.Comments.Count).Reverse();
           List<Animal> TwoPickers =  TwoBestAnimals.Take(2).ToList();
            return View(TwoPickers);
        }
    }
}