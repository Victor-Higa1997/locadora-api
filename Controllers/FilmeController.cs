using locadora_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace locadora_api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>
    {
        new Filme { Id = new Guid(), Titulo = "Matrix", Genero = "Ficção Científica", Duracao = 136 },
        new Filme { Id = new Guid(), Titulo = "O Poderoso Chefão", Genero = "Drama", Duracao = 175 },
        new Filme { Id = new Guid(), Titulo = "O Senhor dos Anéis: O Retorno do Rei", Genero = "Fantasia", Duracao = 201 }
    };

    [HttpPost]
    public IActionResult CadastrarFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);

        return Ok("FilmeController");
    }

    [HttpGet]
    [Route("listarFilmes")]
    public IActionResult ListarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 2)
    {
        return Ok(filmes.Skip(skip).Take(take));
    }

    [HttpGet]
    [Route("listarFilme{titulo}")]
    public IActionResult ListarFilme(string titulo)
    {
        var localizaFilme = filmes.Find(filme => filme.Titulo == titulo);   

        return !string.IsNullOrEmpty(titulo) ? Ok(localizaFilme) : BadRequest();
    }

}
