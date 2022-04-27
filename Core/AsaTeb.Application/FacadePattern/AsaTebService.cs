using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.Candidates.Queries;
using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Application.Technologies.Queries;
using MediatR;

namespace AsaTeb.Application.FacadePattern;

public class AsaTebService : IAsaTebService
{
    private readonly IMediator _mediator;

    public AsaTebService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IEnumerable<TechnologyDto>> GetAllTechnologies()
    {
        return await _mediator.Send(new GetAllTechnologiesQuery());
    }

    public async Task<IEnumerable<CandidateDto>> GetAllCandidates()
    {
        return await _mediator.Send(new GetAllCandidatesQuery());
    }
}