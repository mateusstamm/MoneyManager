using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace RazorPages.Proj.Models;

public class Transaction
{

    [Key]
    public int TransId { get; set; }

    //Category Id
    //Propriedade de navegação
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    public int Amount { get; set; }

    [Column(TypeName = "nvarchar(75)")]
    public string? Note { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    [NotMapped]
    public string? CategoryTitleWithIcon
    {
        get
        {
            return Category == null ? "" : Category.Title;
        }
    }

    [NotMapped]
    public string? FormattedAmount
    {
        get
        {
            string symbol = (Category == null || Category.Type == "Expense") ? "- " : "+ ";
            string formattedValue = Amount.ToString("C0", CultureInfo.GetCultureInfo("pt-BR"));
            return symbol + formattedValue;
        }
}
}