using bijjam_API.Data;
using bijjam_API.Model;
using bijjam_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace bijjam_API.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;
        public HomeRepository(ApplicationDbContext db) 
        {
            _db = db;   
        }
        public async Task CreateAsync(Home entity)
        {
            await _db.Homes.AddAsync(entity);
            await SaveAsync();
        }

        

        public async Task<Home> GetAsync(Expression<Func<Home,bool>> filter = null, bool tracked = true)
        {
            IQueryable<Home> query = _db.Homes;
            if(!tracked) 
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Home>> GetAllAsync(Expression<Func<Home, bool>> filter = null)
        {
            IQueryable<Home> query = _db.Homes;
            if (filter != null) 
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(Home entity)
        {
            _db.Homes.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();   
        }

        public async Task UpdateAsync(Home entity)
        {
            _db.Homes.Update(entity);
            await SaveAsync();  
        }

        
    }
}
