using MagicVilla_API.Modelos;

namespace MagicVilla_API.Repositorio.IRepositorio
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> Update(Villa entidad);
    }
}
