using System.ComponentModel.DataAnnotations;
namespace AspWebProj.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Please enter your comment")]
        [StringLength(50)]
        public string CommentDescription { get; set; }
        public virtual Animal Animal { get; set; }
    }
}