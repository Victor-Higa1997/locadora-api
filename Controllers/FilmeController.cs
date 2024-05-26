using locadora_api.Models;
using locadora_api.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace locadora_api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly IFilmeRepository _filmeRepository;
    public FilmeController(IFilmeRepository filmeRepository)
    {
        _filmeRepository = filmeRepository;
    }

    [HttpPost]
    public IActionResult CadastrarFilme([FromBody] Filme filme)
    {
        _filmeRepository.AdicionarFilme(filme);

        return Ok("Filme cadastrado com sucesso!");
    }

    [HttpGet]
    [Route("listarFilmes")]
    public async Task<IActionResult> ListarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 2)
    {
        var filmes = await _filmeRepository.ObterFilmes();

        return filmes.Any() ? Ok(filmes.Skip(skip).Take(take)) : NotFound();
    }

    [HttpGet]
    [Route("listarFilme{titulo}")]
    public async Task<IActionResult> ListarFilme(string titulo)
    {
        var filme = await _filmeRepository.ObterFilmes();
        var localizaFilme = filme.Where(f => f.Titulo == titulo);

        return !string.IsNullOrEmpty(titulo) ? Ok(localizaFilme) : NotFound();
    }

    [HttpPut]
    [Route("atualizarFilme")]
    public IActionResult AtualizarFilme([FromBody] Filme filme)
    {
        _filmeRepository.AtualizarFilme(filme);

        return Ok("Filme atualizado com sucesso!");
    }

    [HttpDelete]
    [Route("removerFilme")]
    public IActionResult RemoverFilme([FromBody] Filme filme)
    {
        _filmeRepository.RemoverFilme(filme);

        return Ok("Filme removido com sucesso!");
    }

}
