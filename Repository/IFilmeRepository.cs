using locadora_api.Models;

namespace locadora_api.Repositorys;

public interface IFilmeRepository 
{
    Task<IEnumerable<Filme>> ObterFilmes();
    void AdicionarFilme(Filme filme);  
    void RemoverFilme(Filme filme);
    void AtualizarFilme(Filme filme);
    Task<Filme?> ObterFilmePorIdAsync(Guid? id);
}
