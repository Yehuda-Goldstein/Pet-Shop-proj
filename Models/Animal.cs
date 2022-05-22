using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspWebProj.Models
{
    public class Animal
    {
        [Required(ErrorMessage = "Please enter animalId")]
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your age")]
        [Range (0,100)]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter picture name")]
        public string PictureName { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter category id")]
        public int CategoryId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Category Category { get; set; }
    }
}
