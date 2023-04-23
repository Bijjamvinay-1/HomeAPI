using bijjam_API.Data;
using bijjam_API.Model;
using bijjam_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace bijjam_API.Repository
{
    public class HomeRepository : Repository<Home>, IHomeRepository
    {
        private readonly ApplicationDbContext _db;
        public HomeRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;   
        }
       

        public async Task<Home> UpdateAsync(Home entity)
        {
            entity.UpdatedDate = DateTime.Now;  
            _db.Homes.Update(entity);
            await _db.SaveChangesAsync(); 
            return entity;
        }

      
    }
}
