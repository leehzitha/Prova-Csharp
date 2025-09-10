using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace prova.Models;

public class ProvaDbContext(DbContextOptions<ProvaDbContext> opts) : DbContext(opts)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Ponto> Pontos => Set<Ponto>();
    public DbSet<Passeio> Passeios => Set<Passeio>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>()
        .HasMany(u => u.Passeios)
        .WithOne(p => p.User)
        .HasForeignKey(p => p.CreatorID)
        .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Passeio>()
        .HasMany(pa => pa.Pontos)
        .WithMany(p => p.Passeios);

        mb.Entity<Ponto>()
        .HasMany(p => p.Passeios)
        .WithMany(pa => pa.Pontos);
    }
}

public class RPlaceDbContextFactory : IDesignTimeDbContextFactory<ProvaDbContext>
{
    public ProvaDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<ProvaDbContext>();
        var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
        options.UseSqlServer(sqlConn);
        return new ProvaDbContext(options.Options);
    }
}