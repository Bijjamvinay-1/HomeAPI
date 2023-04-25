using bijjam_API.Data;
using bijjam_API.Model;
using bijjam_API.Repository.IRepository;

namespace bijjam_API.Repository
{
    public class HomeNumberRepository : Repository<HomeNumber>, IHomeNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public HomeNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public async Task<HomeNumber> UpdateAsync(HomeNumber entity)
        {
            entity.UpdateDate = DateTime.Now;
            _db.HomeNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }





    }
}
