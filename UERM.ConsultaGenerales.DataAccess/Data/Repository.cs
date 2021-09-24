using UERM.ConsultaGenerales.DataAccess.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UERM.ConsultaGenerales.DataAccess.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        internal DbSet<T> dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public void Add(T Entity)
        {
            dbSet.Add(Entity);
        }

        public void Delete(int Id)
        {
            T EntityToRemove = dbSet.Find(Id);
            dbSet.Remove(EntityToRemove);
        }

        public void Delete(T Entity)
        {
            dbSet.Remove(Entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //IncludeProperties

            if (IncludeProperties != null)
            {
                foreach (var includePropertiesSingular in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePropertiesSingular);
                }
            }

            if (OrderBy != null)
            {
                return OrderBy(query).ToList();
            }

            return query.ToList();
        }

        public T GetById(int Id)
        {
            return dbSet.Find(Id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (IncludeProperties != null)
            {
                foreach (var includePropertiesSingular in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePropertiesSingular);
                }
            }

            return query.FirstOrDefault();
        }
    }
}
