
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ApplicationDbContext : DbContext
{
    public DbSet<TipoCambio> TiposCambio { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=DAVIS\\SQLEXPRESS;Database=BCCR_API;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
    }
}