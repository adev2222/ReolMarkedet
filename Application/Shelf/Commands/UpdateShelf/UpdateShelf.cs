using Application.Common.Repositories;
using Domain.Enums;
using MediatR;

namespace Application.Shelf.Commands.UpdateShelf;

public record UpdateShelfCommand: IRequest
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public ShelfType ShelfType { get; set; }
}

public class UpdateShelfCommandHandler : IRequestHandler<UpdateShelfCommand>
{
    private readonly IShelfRepository _shelfRepository;

    public UpdateShelfCommandHandler(IShelfRepository shelfRepository)
    {
        _shelfRepository = shelfRepository;
    }
    
    public async Task Handle(UpdateShelfCommand request, CancellationToken cancellationToken)
    {
        var shelf = await _shelfRepository.GetByIdAsync(request.Id);
        shelf.Location = request.Location;
        shelf.ShelfType = request.ShelfType;

        await _shelfRepository.UpdateAsync(shelf);
    }
}