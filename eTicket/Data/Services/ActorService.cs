using eTicket.Data.Base;
using eTicket.Models;

namespace eTicket.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>
    {
        public ActorService(AppDbContext context) : base(context)
        {

        }
    }
}