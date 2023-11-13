using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;

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
            var data = await _actorService.GetAllAsync();
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

            await _actorService.AddAsync(actor);
            await _actorService.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<ViewResult> GetById(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            return View("detail", actor);
        }

        [HttpGet("{id}/edit")]
        public async Task<ViewResult> Edit(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            return View(actor);
        }

        [HttpPost("{id}/edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            _actorService.UpdateAsync(actor);
            await _actorService.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}/delete")]
        public async Task<ViewResult> DeleteConfirmed(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            return View("delete", actor);
        }

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor == null) return View("NotFound");

            await _actorService.RemoveAsync(id);
            await _actorService.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}