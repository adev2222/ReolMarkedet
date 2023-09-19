using Application.Common.Repositories;
using AutoMapper;
using MediatR;

namespace Application.ShelfRenter.Queries.GetShelfRenterById;

public record GetShelfRenterByIdQuery(int Id) : IRequest<ShelfRenterByIdDto>;

public class GetShelfRenterByIdQueryHandler : IRequestHandler<GetShelfRenterByIdQuery, ShelfRenterByIdDto>
{
    private readonly IShelfRenterRepository _shelfRenterRepository;
    private readonly IMapper _mapper;

    public GetShelfRenterByIdQueryHandler(IShelfRenterRepository shelfRenterRepository, IMapper mapper)
    {
        _shelfRenterRepository = shelfRenterRepository;
        _mapper = mapper;
    }
    public async Task<ShelfRenterByIdDto> Handle(GetShelfRenterByIdQuery request, CancellationToken cancellationToken)
    {
        var shelfRenter = await _shelfRenterRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ShelfRenterByIdDto>(shelfRenter);
    }
}


