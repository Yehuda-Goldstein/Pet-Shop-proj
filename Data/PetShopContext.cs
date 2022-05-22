using Microsoft.EntityFrameworkCore;
using AspWebProj.Models;
namespace AspWebProj.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Pets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Mamals" },
                new { CategoryId = 2, Name = "Birds" },
                new { CategoryId = 3, Name = "Fish" }
            ); ;

            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, Name = "Zebra", Age = 10, PictureName = "zebra.jfif", Description = "A zebra is an animal from the horse family, and has stripes on its body", CategoryId = 1 },
                 new { AnimalId = 2, Name = "Spizaetus bartelsi", Age = 4, PictureName = "Spizaetus bartelsi.jpg", Description = "It is the symbol of Indonesia", CategoryId = 2 },
                 new { AnimalId = 3, Name = "Common Raven", Age = 4, PictureName = "common raven.jpg", Description = "is a large all-black passerine bird. Found across the Northern Hemisphere, it is the most widely distributed of all corvids.", CategoryId = 2 },
                 new { AnimalId = 4, Name = "hoopoe", Age = 4, PictureName = "hoopoe.jfif", Description = "its a nantional Israel's bird.passerine bird.", CategoryId = 2 },
                 new { AnimalId = 5, Name = "panda", Age = 7, PictureName = "panda.jfif", Description = "Towards the end of the 19th century, the panda became a national symbol in China and its image appears on Chinese gold coins.", CategoryId = 1 },
                 new { AnimalId = 6, Name = "elephant", Age = 10, PictureName = "elephant.jfif", Description = "The most prominent feature of the elephants is the trunk, with which the elephants drink, eat and bathe. Prominent from their mouths are two ivory needles that have made them a target for extensive hunting that has resulted in severe injury to them.", CategoryId = 1 },
                 new { AnimalId = 7, Name = "ibis", Age = 8, PictureName = "ibis.jfif", Description = "its a waterfowl in the family of butterflies. His favorite habitats are swamps and areas near water bodies, in addition to lagoons, floodplains, reservoirs and sewage sites. Magellan has a long, curved beak-like beak.", CategoryId = 2 },
                 new { AnimalId = 8, Name = "salmon", Age = 12, PictureName = "salmon.jfif", Description = "The salmon is a popular edible fish. It is perceived as a relatively healthy food due to the high content of protein in its meat and low levels of fat as well as thanks to the high content of omega 3.", CategoryId = 3 },
                 new { AnimalId = 9, Name = "Mikrogeophagus ramirezi", Age = 6, PictureName = "Mikrogeophagus ramirezi.JPG", Description = "It is an endemic freshwater fish from the Amnon family and is included in the subfamily Geopagins. Its distribution is limited to the Orinoco River Basin, the savannahs of Venezuela, and Colombia in South America. The fish has been tested in studies on fish behavior, and is considered a common aquarium fish. It is about 5 cm in size. It is a quiet fish, whose colors are very varied and colorful.", CategoryId = 3 }

            );
            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, CommentDescription = "Wow", AnimalId = 1 },
                new { CommentId = 2, CommentDescription = "Nice", AnimalId = 2 },
                new { CommentId = 3, CommentDescription = "amazing animal", AnimalId = 3 },
                new { CommentId = 4, CommentDescription = "cute", AnimalId = 4 },
                new { CommentId = 5, CommentDescription = "Wow", AnimalId = 5 },
                new { CommentId = 6, CommentDescription = "Nice", AnimalId = 6 },
                new { CommentId = 7, CommentDescription = "Wow", AnimalId = 7 },
                new { CommentId = 8, CommentDescription = "Nice", AnimalId = 8 },
                new { CommentId = 9, CommentDescription = "Wow", AnimalId = 9 },
                new { CommentId = 10, CommentDescription = "Nice", AnimalId = 2 },
                new { CommentId = 11, CommentDescription = "Awsome", AnimalId = 1 },
                new { CommentId = 12, CommentDescription = "Nice", AnimalId = 3 },
                new { CommentId = 13, CommentDescription = "Wow", AnimalId = 4 },
                new { CommentId = 14, CommentDescription = "Nice", AnimalId = 5 },
                new { CommentId = 15, CommentDescription = "Wow", AnimalId = 6 },
                new { CommentId = 16, CommentDescription = "Nice", AnimalId = 7 }

            ); ;
        }
    }
}