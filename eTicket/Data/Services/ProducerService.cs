using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}