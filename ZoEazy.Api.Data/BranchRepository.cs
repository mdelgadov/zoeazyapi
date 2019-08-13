using ZoEazy.Api.Model;

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