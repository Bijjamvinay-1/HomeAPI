using bijjam_API.Model;

namespace bijjam_API.Repository.IRepository
{
    public interface IHomeNumberRepository : IRepository<HomeNumber>        
    {

        Task<HomeNumber> UpdateAsync(HomeNumber entity);
    }
}
