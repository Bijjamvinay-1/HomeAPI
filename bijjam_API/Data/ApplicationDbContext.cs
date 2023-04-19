using bijjam_API.Model;
using Microsoft.EntityFrameworkCore;

namespace bijjam_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        } 
         public DbSet<Home>Homes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Home>().HasData(
               new Home
               {
                   Id = 1,
                   Name = "Royal Home",
                   Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                   Occupancy = 4,
                   Rate = 200,
                   Sqft = 550,
                   Amenity = "",
                   CreatedDate = DateTime.Now,
               },
              new Home
              {
                  Id = 2,
                  Name = "Premium Pool Home",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
                  Occupancy = 4,
                  Rate = 300,
                  Sqft = 550,
                  Amenity = "",
                  CreatedDate = DateTime.Now,
              },
              new Home
              {
                  Id = 3,
                  Name = "Luxury Pool Home",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                  Occupancy = 4,
                  Rate = 400,
                  Sqft = 750,
                  Amenity = "",
                  CreatedDate = DateTime.Now,
              },
              new Home
              
              {
                  Id = 4,
                  Name = "Diamond Home",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                  Occupancy = 4,
                  Rate = 550,
                  Sqft = 900,
                  Amenity = "",
                  CreatedDate = DateTime.Now,   
              },
              new Home
              
              {
                  Id = 5,
                  Name = "Diamond Pool Home",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
                  Occupancy = 4,
                  Rate = 600,
                  Sqft = 1100,
                  Amenity = "",
                  CreatedDate = DateTime.Now,
              },
              new Home

              {
                  Id = 6,
                  Name = "Diamoend Pool Home",
                  Details = "Fusece 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.covre.windows.net/bluevillaimages/villa2.jpg",
                  Occupancy = 54,
                  Rate = 6050,
                  Sqft = 11500,
                  Amenity = "",
                  CreatedDate = DateTime.Now,
              },
               new Home

               {
                   Id = 7,
                   Name = "Diamoefnd Pool Home",
                   Details = "Fusfece 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://doftnetmasteryimages.blob.covre.windows.net/bluevillaimages/villa2.jpg",
                   Occupancy = 454,
                   Rate = 60540,
                   Sqft = 114500,
                   Amenity = "",
                   CreatedDate = DateTime.Now,
               }

                );
        }

    }
}
