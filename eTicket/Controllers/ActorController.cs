using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            // Validate model is not valid
            if (!ModelState.IsValid)
            {
                // return data to view with model state error
                return View(actor);
            }

            await _actorService.Add(actor);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<ViewResult> GetById(int id)
        {
            var actor = await _actorService.GetById(id);

            if (actor == null) return View("detail", "Empty");

            return View("detail", actor);
        }

        [HttpGet("{id}/edit")]
        public async Task<ViewResult> Edit(int id)
        {
            var actor = await _actorService.GetById(id);

            if (actor == null) return View("Not Found");

            return View(actor);
        }

        [HttpPost("{id}/edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorService.Update(id, actor);

            return RedirectToAction(nameof(Index));
        }
    }
}