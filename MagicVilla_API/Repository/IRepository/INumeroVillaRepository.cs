using MagicVilla_API.Modelos;
using MagicVilla_API.Models;

namespace MagicVilla_API.Repositorio.IRepositorio
{
    public interface INumeroVillaRepository : IRepository<NumeroVilla>
    {
        Task<NumeroVilla> Update(NumeroVilla entidad);
    }
}
