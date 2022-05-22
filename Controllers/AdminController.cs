using AspWebProj.Data;
using AspWebProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace AspWebProj.Controllers
{
    public class AdminController : Controller
    {
        public PetShopContext Context { get; }
        public AdminController(PetShopContext context)
        {
            Context = context;
        }
        public IActionResult AdminPage(int id)
        {
            TempData.Keep("id");
            if (id == 0)
            {
                id = (int)TempData["id"];
            }
            ICollection<Animal> animals = Context.Pets.Where(animal => animal.CategoryId == id).ToList();
            ViewBag.id = id;
            ViewBag.animals = animals;
            IEnumerable<Category> categories = Context.Categories.ToList();
            return View(categories);
        }
        public IActionResult EditPage(int id)
        {
            return View(Context.Pets.FirstOrDefault(animal => animal.AnimalId == id));
        }
        [HttpPost]
        public IActionResult EditAnimal(Animal animal, IFormFile NewPicture)
        {
            string CurrentPicture = "";
            if (NewPicture != null)
            {
                CurrentPicture = NewPicture.FileName;
                FileStream file = new("wwwroot/images/" + NewPicture.FileName, FileMode.OpenOrCreate);
                NewPicture.CopyTo(file);
                file.Close();
            }
            if (NewPicture == null)
            {
                CurrentPicture = animal.PictureName;
            }
            if (ModelState.IsValid)
            {
                Animal NewAnimal = new()
                {
                    AnimalId = animal.AnimalId,
                    Age = animal.Age,
                    Description = animal.Description,
                    Name = animal.Name,
                    PictureName = CurrentPicture,
                    CategoryId = animal.CategoryId
                };
                Context.Pets.Update(NewAnimal);
                Context.SaveChanges();
                TempData["id"] = NewAnimal.CategoryId;
                return RedirectToAction("AdminPage");
            }
            else
            {
                int id = animal.AnimalId;
                return View("EditPage", new { animal = Context.Pets.FirstOrDefault(animal => animal.AnimalId == id) });
            }
        }
        public IActionResult AddingPage()
        {
            ViewBag.Category = Context.Categories.ToList();
            return View("AddAnimalPage");
        }
        public IActionResult AddingAnimal(Animal animal, IFormFile PictureName)
        {
            if (PictureName != null)
            {
                animal.PictureName = PictureName.FileName;
                ModelState.Clear();
            }
            if (TryValidateModel(animal))
            {
                FileStream file = new("wwwroot/images/" + animal.PictureName, FileMode.OpenOrCreate);
                PictureName.CopyTo(file);
                file.Close();
                Context.Pets.Add(animal);
                Context.SaveChanges();
                return RedirectToAction("AdminPage");
            }
            else
            {
                ViewBag.Category = Context.Categories.ToList();
                return View("AddAnimalPage");
            }
        }
        public IActionResult DeleteAnimal(int id)
        {
            var deletedAnimal = Context.Pets.SingleOrDefault(m => m.AnimalId == id);
            TempData["id"] = deletedAnimal.CategoryId;
            Context.Pets.Remove(deletedAnimal);
            Context.SaveChanges();
            return RedirectToAction("AdminPage");
        }
    }
}