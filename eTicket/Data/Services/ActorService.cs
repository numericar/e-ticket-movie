using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var actors = await _context.Actors.ToListAsync();
            return actors;
        }

        public Task<Actor> GetById(int id)
        {
            throw new NotImplementedException();
        }


        public async Task Add(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public Task Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}