using Application.Common.Repositories;
using Application.Shelf.Commands.CreateShelf;
using MediatR;

namespace Application.Shelf.Commands.DeleteShelf;

public record DeleteShelfCommand(int Id): IRequest;

public class DeleteShelfCommandHandler : IRequestHandler<DeleteShelfCommand>
{
    private readonly IShelfRepository _shelfRepository;


    public DeleteShelfCommandHandler(IShelfRepository shelfRepository)
    {
        this._shelfRepository = shelfRepository;
    }
    public async Task Handle(DeleteShelfCommand request, CancellationToken cancellationToken)
    {
        var shelf = await _shelfRepository.GetByIdAsync(request.Id);
        await _shelfRepository.DeleteAsync(shelf);
        
    }
}