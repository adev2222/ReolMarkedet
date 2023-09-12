using MediatR;

namespace Application.LeaseAgreement.Commands.CreateLeaseAgreement;

public class CreateLeaseAgreementCommand: IRequest<int>
{
    public DateTime StartDate { get; set; }

    public int RentDuration { get; set; }
}

