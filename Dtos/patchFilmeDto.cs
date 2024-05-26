namespace locadora_api.Dtos
{
    public record patchFilmeDto
    {
        public string? Titulo { get; init; }
        public string? Genero { get; init; }
        public int? Duracao { get; init; }

    }
}
