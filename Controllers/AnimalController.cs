using AspWebProj.Data;
using AspWebProj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace AspWebProj.Controllers
{
    public class AnimalController : Controller
    {
        public PetShopContext Context { get; }
        public AnimalController(PetShopContext context)
        {
            Context = context;
        }
        public IActionResult ShowAnimalPage(int id)
        {
           var animal=Context.Pets.FirstOrDefault(animal => animal.AnimalId == id);
            animal.Comments = Context.Comments.Where(animal => animal.AnimalId == id).ToList();
            ViewBag.Category = Context.Categories.FirstOrDefault
                (a => a.Animals.First(b => b == animal) == animal);
            ViewBag.Animal = animal;
            return View();
        }
        public IActionResult AddComment(Comment comment)
        {
            Context.Comments.Add(comment);
            Context.SaveChanges();
           return RedirectToAction("ShowAnimalPage" , new {id = comment.AnimalId });
        }
    }
}