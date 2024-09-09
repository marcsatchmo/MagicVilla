using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Models;
using MagicVilla_API.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace MagicVilla_API.Repositorio
{
    public class NumeroVillaRepository : Repository<NumeroVilla>, INumeroVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public NumeroVillaRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

        public async Task<NumeroVilla> Update(NumeroVilla entidad)
        {
            entidad.FechaActualizacion = DateTime.Now;
            _db.NumeroVillas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}
