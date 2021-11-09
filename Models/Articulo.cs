using System.ComponentModel.DataAnnotations;

namespace ApiCRUD.Models
{
    public class Articulo
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string descripcion { get; set; }

        [Required]
        public decimal precio { get; set; }

        [Required]
        public bool estado { get; set; }

    }
}