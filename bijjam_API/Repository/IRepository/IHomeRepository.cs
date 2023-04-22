using bijjam_API.Model;
using System.Linq.Expressions;

namespace bijjam_API.Repository.IRepository
{
    public interface IHomeRepository
    {

        Task<List<Home>>GetAllAsync(Expression<Func<Home,bool>>filter = null);
        Task<Home> GetAsync(Expression<Func<Home, bool>> filter = null, bool tracked=true);
        Task CreateAsync(Home entity);
        Task UpdateAsync(Home entity);
        Task RemoveAsync(Home entity);
        
        
        Task SaveAsync(); 
        





    }
}
