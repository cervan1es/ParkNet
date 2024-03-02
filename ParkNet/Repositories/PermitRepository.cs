using PARKNET.Data;
using PARKNET.Data.Entities;

namespace PARKNET.Repositories
{
    public class PermitRepository
    {
        private readonly ApplicationDbContext _context;
        public PermitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Permit> GetPermits()
        {
            return _context.Permit.ToList();
        }

        public void UpdatePermit(Permit permit)
        {
            _context.Permit.Update(permit);
            _context.SaveChanges();
        }
    }
}
