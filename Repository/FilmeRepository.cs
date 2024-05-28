using locadora_api.Context;
using locadora_api.Models;
using Microsoft.EntityFrameworkCore;

namespace locadora_api.Repositorys;

public class FilmeRepository : IFilmeRepository
{
    private readonly FilmesDbContext _context;

    public FilmeRepository(FilmesDbContext context)
    {
        _context = context;
    }

    public void AdicionarFilme(Filme filme)
    {
        _context.Filmes.Add(filme);
        _context.SaveChanges();
    }

    public void AtualizarFilme(Filme filme)
    {
        _context.Filmes.Update(filme);
        _context.SaveChanges();
    }

    public async Task<IEnumerable<Filme>> ObterFilmes()
    {
        IEnumerable<Filme> filmes = await _context.Filmes.ToListAsync(); 
        return filmes;
    }

    public void RemoverFilme(Filme filme)
    {
        _context.Filmes.Remove(filme);
        _context.SaveChanges();
    }

    public async Task<Filme?> ObterFilmePorIdAsync(Guid? id)
    {
        Filme? filme = await _context.Filmes.FirstOrDefaultAsync(f => f.Id == id);
        return filme;
    }
}
