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

    public async Task<IEnumerable<TechnologyDto>> GetAllTechnologiesAsync()
    {
        return await _mediator.Send(new GetAllTechnologiesQuery());
    }

    public async Task<TechnologyDto> GetTechnologyByIdAsync(Guid id)
    {
        return await _mediator.Send(new GetTechnologyByIdQuery(Id: id));
    }

    public async Task<IEnumerable<CandidateDto>> GetAllCandidatesAsync()
    {
        return await _mediator.Send(new GetAllCandidatesQuery());
    }

    public async Task<IEnumerable<CandidateDto>> FilterCandidatesAsync(CandidateByDto candidateByDto)
    {
        return await _mediator.Send(new FilterCandidatesQuery(CandidateByDto: candidateByDto));
    }
}