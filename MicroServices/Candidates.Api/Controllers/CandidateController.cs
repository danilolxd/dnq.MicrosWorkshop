using Microsoft.AspNetCore.Mvc;

namespace Candidates.Api.Controllers;

[ApiController]
public class CandidateController : ControllerBase
{
    // Listar candidatos a partir de un ID de oferta
    // Obtener el detalle de un candidato
    // Crear un nuevo candidato (al crear un candidato deberemos de publicar un evento para que el microservicio de ofertas sepa que se ha añadido un nuevo candidato)

    private readonly ILogger<CandidateController> _logger;

    public CandidateController(ILogger<CandidateController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// List ALL candidates
    /// </summary>
    /// <returns></returns>
    [HttpGet("candidates")]
    public async Task<List<CandidateDto>>  GetCandidatesAsync()
    {
        var candidates = new List<CandidateDto>
        {
            new CandidateDto(),
            new CandidateDto()
        };

        return candidates;
    }
}

public class CandidateDto
{
    public Guid IdCandidate { get; set; }
    public long IdVacancy { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public CandidateDto()
    {
        var rnd = new Random();

        IdCandidate = Guid.NewGuid();
        IdVacancy = rnd.NextInt64(3000, 10000);
        Name = "CandidateName";
        Surname = "CandidateSurname";
        Email = "email@email.com";
    }
}
