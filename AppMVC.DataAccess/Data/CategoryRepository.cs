using AppMVC.DataAccess.Data.Repository;
using AppMVC.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppMVC.DataAccess.Data
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _context.Categories.Select(i => new SelectListItem() { 
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }

        public void Update(Category Category)
        {
            var oCategory = _context.Categories.FirstOrDefault(f => f.Id == Category.Id);
            
            if (oCategory != null)
            {
                oCategory.Nombre = Category.Nombre;
                oCategory.Orden = Category.Orden;

                _context.SaveChanges();
            }
        }
    }
}
