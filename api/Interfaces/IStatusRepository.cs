using api.Entity;

namespace api.Interfaces
{
    public interface IStatusRepository
    {
        public Task<Status?> Check(long statusId);
    }
}
