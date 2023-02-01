using SistemaWebMisRecetas.Validations;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebMisRecetas.Models
{
    public class Receta
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        [CategoriaDesayuno]
        public string Categoria { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Ingredientes { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Instrucciones { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        [EdadMayorQue]
        public int Edad { get; set; }

        [Required]
        [RegularExpression("^[^@]+@[^@]+\\.[a-zA-Z]{2,}$")]
        public string Email { get; set; }
    }
}
