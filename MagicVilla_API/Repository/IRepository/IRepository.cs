using System.Linq.Expressions;

namespace MagicVilla_API.Repositorio.IRepositorio
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entidad);

        Task<List<T>> GetAll(Expression<Func<T, bool>>? filtro = null);

        bool Any(Expression<Func<T, bool>> filtro);

        Task<T> Get(Expression<Func<T, bool>>? filtro = null, bool tracked=true);

        Task Remove(T entidad);

        Task Save();
    }
}
