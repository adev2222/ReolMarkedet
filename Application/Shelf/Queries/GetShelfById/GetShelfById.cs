using Application.Common.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Shelf.Queries.GetShelfById;

public record GetShelfByIdQuery: IRequest<ShelfDto>
{
    public int Id { get; set; }
}

public class GetShelfByIdQueryHandler : IRequestHandler<GetShelfByIdQuery, ShelfDto>
{
    private readonly IMapper _mapper;
    private readonly IShelfRepository _shelfRepository;

    public GetShelfByIdQueryHandler(IMapper mapper, IShelfRepository shelfRepository)
    {
        _mapper = mapper;
        _shelfRepository = shelfRepository;
    }
    
    
    public async Task<ShelfDto> Handle(GetShelfByIdQuery request, CancellationToken cancellationToken)
    {
        var shelf = await _shelfRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ShelfDto>(shelf);
    }
}