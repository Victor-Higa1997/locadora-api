using locadora_api.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace locadora_api.Context
{
    public class FilmesDbContext : DbContext
    {
        public FilmesDbContext(DbContextOptions<FilmesDbContext> options) : base(options)
        {
        }

        DbSet<Filme> Filmes { get; set; }
    }

}
