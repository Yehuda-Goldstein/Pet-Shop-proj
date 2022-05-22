using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspWebProj.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }

    }
}
