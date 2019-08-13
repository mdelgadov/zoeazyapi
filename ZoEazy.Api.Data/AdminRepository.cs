using System;
using System.Collections.Generic;
using System.Linq;
using ZoEazy.Api.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ZoEazy.Api.Data
{
    public class AdminRepository<T> : IAdminRepository<T> where T : class, IId
    {
        private readonly ZoeazyDbContext context; // = new ZoeazyDbContext();
       
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public AdminRepository(ZoeazyDbContext _context)
        {
            context = _context;
            entities = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public async Task<T> Get(long id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<T> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}