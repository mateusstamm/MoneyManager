using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Pages.Models
{
    public class CategoriaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaID { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string ?Nome { get; set; }

        public string ?Descricao { get; set; }
        public string ?Tipo { get; set; }
    }
}