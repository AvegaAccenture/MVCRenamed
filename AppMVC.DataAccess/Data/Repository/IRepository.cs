using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppMVC.DataAccess.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T Entity);
        void Delete(int Id);
        void Delete(T Entity); //Eliminar por Identidad
        T GetById(int Id);
        /// <summary>
        /// Este método trae una lista de todos los registros, pero también tiene como opción añadir filtros.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="OrderBy"></param>
        /// <param name="IncludeProperties"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
            string IncludeProperties = null
            );
        /// <summary>
        /// Este método trae un registro según su filtro.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="IncludeProperties"></param>
        /// <returns></returns>
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string IncludeProperties = null
            );
    }
}
