using api.Dtos.Status;
using api.Entity;

namespace api.Mappers
{
    public static class StatusMapppers
    {
        public static Status ToStatus(this StatusDto statusDto)
        {
            return new Status
            {
                Description = statusDto.Description,
            };
        }

    }
}
