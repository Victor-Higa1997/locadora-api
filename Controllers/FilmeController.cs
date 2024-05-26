using AutoMapper;
using locadora_api.Dtos;
using locadora_api.Models;
using locadora_api.Repositorys;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace locadora_api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly IFilmeRepository _filmeRepository;
    private IMapper _mapper;
    public FilmeController(IFilmeRepository filmeRepository, IMapper mapper)
    {
        _filmeRepository = filmeRepository;
        _mapper = mapper;   
    }

    [HttpPost]
    public IActionResult CadastrarFilme([FromBody] FilmeDto filmeDto)
    {
        var filme = _mapper.Map<Filme>(filmeDto);
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

    [HttpPatch("patchFilme{id}")]
    public  IActionResult PatchFilme(Guid id, JsonPatchDocument<patchFilmeDto> patch)
    {
        var todosFilmes = _filmeRepository.ObterFilmes().Result;
        var filme  = todosFilmes.FirstOrDefault(f => f.Id == id);

        if (filme == null) return NotFound();
        
        var filmeAtualizar = _mapper.Map<patchFilmeDto>(filme);
        patch.ApplyTo(filmeAtualizar, ModelState);

        if (!TryValidateModel(filmeAtualizar)) return ValidationProblem(ModelState);

        _mapper.Map(filmeAtualizar, filme);
        _filmeRepository.AtualizarFilme(filme);
        return NoContent();
    }

}
