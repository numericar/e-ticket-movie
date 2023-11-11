using eTicket.Data;
using eTicket.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    [Route("[controller]")]
    public class ActorController : Controller
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<ViewResult> Index()
        {
            var data = await _actorService.GetAll();
            return View(data);
        }

        // Get: actor/create
        [HttpGet("create")]
        public ViewResult Create()
        {
            return View();
        }
    }
}