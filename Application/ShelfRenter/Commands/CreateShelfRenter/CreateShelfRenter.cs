using Application.Common.Repositories;
using MediatR;

namespace Application.ShelfRenter.Commands.CreateShelfRenter;

public record CreateShelfRenterCommand: IRequest<int>
{
    public string? FirstName { get; set; } 
    public string? LastName { get; set; } 
    public string Email { get; set; }
    public string? Phone { get; set; } 
}

public class CreateShelfRenterCommandHandler : IRequestHandler<CreateShelfRenterCommand, int>
{
    private readonly IShelfRenterRepository _shelfRenterRepository;

    public CreateShelfRenterCommandHandler(IShelfRenterRepository shelfRenterRepository)
    {
        _shelfRenterRepository = shelfRenterRepository;
    }
    public async Task<int> Handle(CreateShelfRenterCommand request, CancellationToken cancellationToken)
    {
        var shelfRenter = new Domain.Entities.ShelfRenter
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            Email = request.Email
                
        };
        await _shelfRenterRepository.CreateAsync(shelfRenter);
        return shelfRenter.Id;
    }
}

