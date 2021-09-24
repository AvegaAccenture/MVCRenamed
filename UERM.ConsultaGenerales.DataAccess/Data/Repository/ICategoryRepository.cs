using UERM.ConsultaGenerales.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UERM.ConsultaGenerales.DataAccess.Data.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetListaCategorias();
        void Update(Category Category);
    }
}
