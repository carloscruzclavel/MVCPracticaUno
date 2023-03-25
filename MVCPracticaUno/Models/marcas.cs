using System.ComponentModel.DataAnnotations;

namespace MVCPracticaUno.Models
{
    public class marcas
    {
        [Key]
        public int id_marcas { get; set; }
        [Display(Name = "Nombre de la marca")]
        public string? nombre_marca { get; set; }
        [Display(Name = "Estado de la Marca (A: Activo, I: Inactivo)")]
        public string? estados { get; set; }
    }
}
