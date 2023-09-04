using Application.Common.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Shelf.Queries.GetShelfList;

public record GetShelvesQuery: IRequest<List<ShelvesDto>>;


public class GetShelvesQueryHandler : IRequestHandler<GetShelvesQuery, List<ShelvesDto>>
{
    private readonly IMapper _mapper;
    private readonly IShelfRepository _shelfRepository;

    public GetShelvesQueryHandler(IMapper mapper, IShelfRepository shelfRepository)
    {
        _mapper = mapper;
        _shelfRepository = shelfRepository;
    }
    
    public async Task<List<ShelvesDto>> Handle(GetShelvesQuery request, CancellationToken cancellationToken)
    {
        var shelves = await _shelfRepository.GetAsync();
        
        return _mapper.Map<List<ShelvesDto>>(shelves);
   
    }
}