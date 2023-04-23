using bijjam_API.Model;
using System.Linq.Expressions;

namespace bijjam_API.Repository.IRepository
{
    public interface IHomeRepository : IRepository<Home>    
    {

        Task<Home> UpdateAsync(Home entity);






    }
}
