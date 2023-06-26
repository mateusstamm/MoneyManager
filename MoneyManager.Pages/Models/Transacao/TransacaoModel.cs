using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Pages.Models
{
    public class TransacaoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransacaoID { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string ?Nome { get; set; }

        public string ?Descricao { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório!")]
        public decimal ?Valor { get; set; }

        [ForeignKey("Categoria")]
        public int? CategoriaID { get; set; }

        public CategoriaModel? Categoria { get; set; }

        public DateTime ?Data { get; set; }
    }
}
