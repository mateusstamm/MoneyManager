using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.API.Models
{
    public class TransacaoModel
    {
        [Key]
        public int TransacaoID { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [ForeignKey("Categoria")]
        public int? CategoriaID { get; set; }

        public CategoriaModel? Categoria { get; set; }

    }
}
