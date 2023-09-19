using Application.Common.Repositories;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class LeaseAgreementRepository : GenericRepository<Domain.Entities.LeaseAgreement>, ILeaseAgreementRepository
{
    public LeaseAgreementRepository(ApplicationDbContext context) : base(context)
    {
    }

    public new async Task CreateAsync(LeaseAgreement entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}