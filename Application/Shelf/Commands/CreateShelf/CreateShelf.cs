using Application.Common.Repositories;
using AutoMapper;
using Domain.Enums;
using MediatR;

namespace Application.Shelf.Commands.CreateShelf;

public record CreateShelfCommand : IRequest<int>
{
    public string Location { get; set; } = string.Empty;
    public ShelfType ShelfType { get; set; } = ShelfType.withoutGLasses;
}

public class CreateShelfCommandHandler : IRequestHandler<CreateShelfCommand, int>
{
    private readonly IShelfRepository _shelfRepository;


    public CreateShelfCommandHandler(IShelfRepository shelfRepository)
    {
        this._shelfRepository = shelfRepository;
    }
    public async Task<int> Handle(CreateShelfCommand request, CancellationToken cancellationToken)
    {
        var shelf = new Domain.Entities.Shelf
        {
            Location = request.Location,
            ShelfType = request.ShelfType
        };
        
        await _shelfRepository.CreateAsync(shelf);

        return shelf.Id;
    }
}