using System.Globalization;
using RazorPages.Proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RazorPages.Proj.Controllers;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index(){
        //transacoes dos ultimos 10 dias
        DateTime StartDate = DateTime.Today.AddDays(-10);
        DateTime EndDate = DateTime.Today;

        List<Transaction> SelectedTransactions = await _context.Transactions
            .Include(x => x.Category)
            .Where(y => y.Date >= StartDate && y.Date <= EndDate).ToListAsync();

        int TotalIncome = SelectedTransactions.Where(y => y.Category.Type == "Income").Sum(j => j.Amount);
        CultureInfo cultureIncome = CultureInfo.CreateSpecificCulture("pt-BR");
        cultureIncome.NumberFormat.CurrencySymbol = "R$";
        ViewBag.TotalIncome = TotalIncome.ToString("C0", cultureIncome);

        int TotalExpense = SelectedTransactions.Where(y => y.Category.Type == "Expense").Sum(j => j.Amount);
        CultureInfo cultureExpense = CultureInfo.CreateSpecificCulture("pt-BR");
        cultureExpense.NumberFormat.CurrencySymbol = "R$";
        ViewBag.TotalExpense = TotalExpense.ToString("C0", cultureExpense);


        //Balance
        int Balance = TotalIncome - TotalExpense;
        CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");
        culture.NumberFormat.CurrencyNegativePattern = 1;
        culture.NumberFormat.CurrencySymbol = "R$";
        ViewBag.Balance = String.Format(culture, "{0:C0}", Balance);

        //grafico Doughnut - gastos por categoria
        ViewBag.DoughnutChartData = SelectedTransactions.Where(x => x.Category.Type == "Expense")
            .GroupBy(j => j.CategoryId)
            .Select(m => new {
                CategoryTitleWithIcon = m.First().Category.Icon + " " + m.First().Category.Title,
                amount = m.Sum(j => j.Amount),
                formattedAmount = m.Sum(j => j.Amount).ToString("C0", CultureInfo.GetCultureInfo("pt-BR"))
            })
            .OrderByDescending(l => l.amount)
            .ToList();

        

        //grafico spline: ganhos vs despesas
        //Ganhos
        List<SplineChartData> incomeSummary = SelectedTransactions.Where(i => i.Category.Type == "Income")
            .GroupBy(i => i.Date)
            .Select(i => new SplineChartData(){
                weeks = i.First().Date.ToString("dd-MMM"),
                income = i.Sum(l => l.Amount)
            }).ToList();

        //Despesas
        List<SplineChartData> expenseSummary = SelectedTransactions.Where(i => i.Category.Type == "Expense")
            .GroupBy(i => i.Date)
            .Select(i => new SplineChartData(){
                weeks = i.First().Date.ToString("dd-MMM"),
                expense = i.Sum(l => l.Amount)
            }).ToList();
        
        //combinação de ganhos e despesas
        string[] last10Days = Enumerable.Range(0,10).Select(i => StartDate.AddDays(i).ToString("dd-MMM")).ToArray();

        ViewBag.SplineChartData = from week in last10Days
                                    join income in incomeSummary on week equals income.weeks into dayIncomejoined
                                    from income in dayIncomejoined.DefaultIfEmpty()
                                    join expense in expenseSummary on week equals expense.weeks into expensejoined
                                    from expense in expensejoined.DefaultIfEmpty()
                                    select new {
                                        week = week,
                                        income = income == null ? 0 : income.income,
                                        expense = expense == null ? 0 : expense.expense
                                    };

        //transacoes recentes
        ViewBag.RecentTrans = await _context.Transactions
            .Include(i => i.Category)
            .OrderByDescending(i => i.Date)
            .Take(3)
            .ToListAsync();
        return View();
    }
}

public class SplineChartData {
    public string weeks;
    public int income;
    public int expense;
}