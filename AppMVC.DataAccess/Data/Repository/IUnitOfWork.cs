using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVC.DataAccess.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }


        void Save();
    }
}
