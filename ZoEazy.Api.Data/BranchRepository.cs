using ZoEazy.Api.Model.Branch;

namespace ZoEazy.Api.Data
{
    public class BranchRepository : AdminRepository<Branch>
    {
        public BranchRepository(ZoeazyDbContext _context)
            : base(_context)
        {

        }
    }
}