using UERM.ConsultaGenerales.DataAccess.Data.Repository;
using UERM.ConsultaGenerales.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UERM.ConsultaGenerales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CategoriesController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Add(category);
                _UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Category oCategory = new Category();
            oCategory = _UnitOfWork.Category.GetById(Id);

            if (oCategory == null)
            {
                return NotFound();
            }

            return View(oCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Update(category);
                _UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }


        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var ObjDb = _UnitOfWork.Category.GetById(Id);

            if (ObjDb == null)
            {
                return Json(new {  success = false, message = "Error al eliminar la Categoría."});
            }

            _UnitOfWork.Category.Delete(ObjDb);
            _UnitOfWork.Save();

            return Json(new { success = true, message = "Categoría eliminada correctamente."});
        }


        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _UnitOfWork.Category.GetAll() });
        }
        #endregion
    }
}
