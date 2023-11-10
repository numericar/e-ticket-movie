using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    [Route("[controller]")]
    public class ActorController : Controller
    {
        private readonly AppDbContext context;

        public ActorController(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ViewResult> Index()
        {
            var data = await this.context.Actors.ToListAsync();
            return View(data);
        }
    }
}