using AsaTeb.Application.Technologies.Dtos;
using AsaTeb.Application.Technologies.Queries;
using MediatR;

namespace AsaTeb.Application.FacadePattern;

public class AsaTebService: IAsaTebService
{
    private readonly IMediator _mediator;

    public AsaTebService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IList<TechnologyDto>> GetAllTechnologies()
    {
        return await _mediator.Send(new GetAllTechnologiesQuery());
    }
}