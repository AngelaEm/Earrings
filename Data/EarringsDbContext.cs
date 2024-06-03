using earrings.Models;
using Microsoft.EntityFrameworkCore;

namespace earrings.Data
{
    public class EarringsDbContext : DbContext
    {
        public EarringsDbContext(DbContextOptions<EarringsDbContext> options) : base(options)
        {
        }

        public DbSet<Earrings> Earrings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Earrings>().HasData(
                               new Earrings
                               {
                                   Id = new System.Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b"),
                                   Name = "Avokados",
                                   Description = "Söta hängande avokadoörhängen",
                                   Price = 50.00,
                                   Image = "/avokado.png"
                               },
                                              new Earrings
                                              {
                                                  Id = new System.Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c"),
                                                  Name = "Spöken",
                                                  Description = "Spökörhängen. Perfekta till Halloween!",
                                                  Price = 50.00,
                                                  Image = "/spoken.png"
                                              },
                                              new Earrings
                                              {
                                                  Id = new System.Guid("f5b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3d"),
                                                  Name = "Hundtassar",
                                                  Description = "Tassar till husse eller matte!",
                                                  Price = 50.00,
                                                  Image = "/tassar.png"
                                              }
                                          );
        }
    }
}
