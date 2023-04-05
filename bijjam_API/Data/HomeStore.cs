using bijjam_API.Model.DTO;
///
namespace bijjam_API.Data
{
    public  static class HomeStore
    {
       public static List<HomeDTO> HomeList = new List<HomeDTO> {
            new HomeDTO { Id = 1, Name ="Pool View"},

            new HomeDTO { Id = 2, Name = "Beach View",Sqft =100, Occupancy =4 },
            new HomeDTO { Id = 3, Name = "Green View" ,Sqft =300, Occupancy =5}

            };

    }
}
