using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVC.Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingresa un nombre para la categoría.")]
        [Display(Name = "Nombre de Categoría")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Orden de Categoría")]
        public int Orden { get; set; }
    }
}
