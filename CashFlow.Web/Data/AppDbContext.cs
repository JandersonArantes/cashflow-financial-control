using Microsoft.EntityFrameworkCore;
using CashFlow.Web.Models;

namespace CashFlow.Web.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Lancamento> Lancamentos { get; set; }
    }
}
