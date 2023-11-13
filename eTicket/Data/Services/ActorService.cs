using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {
        public ActorService(AppDbContext context) : base(context)
        {

        }
    }
}