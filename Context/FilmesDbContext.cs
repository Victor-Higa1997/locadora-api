using locadora_api.Models;
using Microsoft.EntityFrameworkCore;

namespace locadora_api.Context;
public class FilmesDbContext : DbContext
{
    public FilmesDbContext(DbContextOptions<FilmesDbContext> options) : base(options)
    {
    }

    public DbSet<Filme> Filmes { get; set; }
}
