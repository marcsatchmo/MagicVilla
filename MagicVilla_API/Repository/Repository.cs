using MagicVilla_API.Datos;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace MagicVilla_API.Repositorio
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> filtro)
        {
            IQueryable<T> query = dbSet;

           return query.Any(filtro);
        }

        public async Task Create(T entidad)
        {
            await dbSet.AddAsync(entidad);
            await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>>? filtro = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if(filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filtro = null) 
        {
            IQueryable<T> query = dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.ToListAsync();

        }

        public async Task Remove(T entidad)
        {
            dbSet.Remove(entidad);
            await Save();
        }
    }
}
