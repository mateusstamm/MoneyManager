using System.ComponentModel.DataAnnotations;

namespace MoneyManager.API.Models
{
    public class CategoriaModel
    {
        [Key]
        public int CategoriaID { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
