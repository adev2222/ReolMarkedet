using Application.Common.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class LeaseAgreementsRepository: GenericRepository<Domain.Entities.LeaseAgreements>, ILeaseAgreementsRepository
{
    public LeaseAgreementsRepository(ApplicationDbContext context) : base(context)
    {
    }
}