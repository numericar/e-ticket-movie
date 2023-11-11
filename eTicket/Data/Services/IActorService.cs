using eTicket.Models;

namespace eTicket.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor> GetById(int id);
        Task Add(Actor actor);
        Task Update(int id, Actor newActor);
        Task DeleteById(int id);
    }
}