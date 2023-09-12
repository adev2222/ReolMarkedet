using Application.Common.Repositories;
using AutoMapper;
using MediatR;

namespace Application.ShelfRenter.Queries.GetShelfRentersList;

public record GetShelfRentersListQuery : IRequest<List<ShelfRentersListDto>>;

public class GetShelfRentersListQueryHandler : IRequestHandler<GetShelfRentersListQuery, List<ShelfRentersListDto>>
{
    private readonly IShelfRenterRepository _shelfRenterRepository;
    private readonly IMapper _mapper;

    public GetShelfRentersListQueryHandler(IShelfRenterRepository shelfRenterRepository, IMapper mapper)
    {
        _shelfRenterRepository = shelfRenterRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ShelfRentersListDto>> Handle(GetShelfRentersListQuery request, CancellationToken cancellationToken)
    {
        var shelfRenters = await _shelfRenterRepository.GetAsync();
        return _mapper.Map<List<ShelfRentersListDto>>(shelfRenters);
    }
}