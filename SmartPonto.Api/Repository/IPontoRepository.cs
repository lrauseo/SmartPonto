using System.Threading.Tasks;

namespace SmartPonto.Api.Repository
{
    public interface IPontoRepository
    {
         //Geral
         void Add<T>(T entity)where T:class;
         void Update<T>(T entity)where T:class;
         void Delete<T>(T entity)where T:class;

         Task AddAsync<T>(T entity)where T:class;

         Task<bool> SaveChangesAsync();

    }
}