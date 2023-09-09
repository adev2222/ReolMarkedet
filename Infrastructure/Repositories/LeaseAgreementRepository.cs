using Application.Common.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class LeaseAgreementRepository: GenericRepository<Domain.Entities.LeaseAgreement>, ILeaseAgreementRepository
{
    public LeaseAgreementRepository(ApplicationDbContext context) : base(context)
    {
    }
}