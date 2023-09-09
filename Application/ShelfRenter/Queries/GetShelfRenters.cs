using Application.Common.Repositories;
using AutoMapper;
using MediatR;

namespace Application.ShelfRenter.Queries;

public class GetShelfRentersQuery : IRequest<List<ShelfRentersDto>>
{
    
}

public class GetShelfRentersQueryHandler : IRequestHandler<GetShelfRentersQuery, List<ShelfRentersDto>>
{
    private readonly IShelfRenterRepository _shelfRenterRepository;
    private readonly IMapper _mapper;

    public GetShelfRentersQueryHandler(IShelfRenterRepository shelfRenterRepository, IMapper mapper)
    {
        _shelfRenterRepository = shelfRenterRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ShelfRentersDto>> Handle(GetShelfRentersQuery request, CancellationToken cancellationToken)
    {
        var shelfRenters = await _shelfRenterRepository.GetAsync();
        return _mapper.Map<List<ShelfRentersDto>>(shelfRenters);
    }
}