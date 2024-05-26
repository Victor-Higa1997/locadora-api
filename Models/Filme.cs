using locadora_api.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace locadora_api.Models;

public class Filme : BaseId
{
    [Required(ErrorMessage = "O titulo do filme é obrigatorio")]
    public string? Titulo { get; set; } = "Sem titulo";
    [Required(ErrorMessage = "O genero do filme é obrigatorio")]
    public string? Genero { get; set; } = "Sem genero";
    [Range(60, 600, ErrorMessage = "A duaracao minima do filme é entre 60 a 600 minutos")]
    public int Duracao { get; set; } = 200;
}
