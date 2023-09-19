using Application.Common.Repositories;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.LeaseAgreement.Commands.CreateLeaseAgreement;

public record CreateLeaseAgreementCommand: IRequest<int>
{
    
    public DateTime StartDate { get; set; }

    public int RentDuration { get; set; }
    
    public double Price { get; set; }

    public ShelfType ShelfType { get; set; } = ShelfType.withoutGLasses;
    public string Email { get; set; }
    
}

public class CreateLeaseAgreementCommandHandler : IRequestHandler<CreateLeaseAgreementCommand, int>
{
    private readonly ILeaseAgreementRepository _leaseAgreementRepository;
    private readonly IShelfRenterRepository _shelfRenterRepository;
    private readonly IShelfRepository _shelfRepository;
    private readonly IGenericInterface<ShelfLeaseAgreement> _leaseAgreementShelf;

    public CreateLeaseAgreementCommandHandler(ILeaseAgreementRepository leaseAgreementRepository, 
        IShelfRenterRepository shelfRenterRepository,
        IShelfRepository shelfRepository, IGenericInterface<ShelfLeaseAgreement> leaseAgreementShelf)
    {
        _leaseAgreementRepository = leaseAgreementRepository;
        _shelfRenterRepository = shelfRenterRepository;
        _shelfRepository = shelfRepository;
        _leaseAgreementShelf = leaseAgreementShelf;
    }
    
    public async Task<int> Handle(CreateLeaseAgreementCommand leaseAgreementDto, CancellationToken cancellationToken)
    {
        
        var shelf = await _shelfRepository.GetByDateTime(leaseAgreementDto.StartDate) ??
                   throw new Exception("Could not find available shelf");
        
        shelf.BookingEndDate = leaseAgreementDto.StartDate.AddDays(leaseAgreementDto.RentDuration * 7);
        
        await _shelfRepository.UpdateAsync(shelf);

        
        var shelfRenter = await _shelfRenterRepository.FindByEmailOrCreate(leaseAgreementDto.Email);
     
        var leaseAgreement = new Domain.Entities.LeaseAgreement
        {
            StartDate = leaseAgreementDto.StartDate,
            RentDuration = leaseAgreementDto.RentDuration,
            ShelfRenterId = shelfRenter.Id,
            Price = leaseAgreementDto.Price,
        };
        

        await _leaseAgreementRepository.CreateAsync(leaseAgreement);

         await _leaseAgreementShelf.CreateAsync(new ShelfLeaseAgreement
        {
             LeaseAgreementId = leaseAgreement.Id,
             ShelfId = shelf.Id,
         });

        return leaseAgreement.Id;
    }
}
