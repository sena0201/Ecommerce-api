using api.Data;
using api.Entity;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDBContext _context;
        public StatusRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Status?> Check(long statusId)
        {
            var status = await _context.Status.FirstOrDefaultAsync(s => s.StatusId == statusId);
            if (status == null)
            {
                return null;
            }
            return status;
        }
    }
}
