using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}