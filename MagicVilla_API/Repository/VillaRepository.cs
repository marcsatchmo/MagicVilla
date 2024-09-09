using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace MagicVilla_API.Repositorio
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

        public async Task<Villa> Update(Villa entidad)
        {
            entidad.FechaActualizacion = DateTime.Now;
            _db.Villas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}
