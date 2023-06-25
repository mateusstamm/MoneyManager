using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Pages.Models
{
    public class CategoriaModel
    {
        [Key]
        public int CategoriaID { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string ?Nome { get; set; }

        public string ?Descricao { get; set; }
    }
}