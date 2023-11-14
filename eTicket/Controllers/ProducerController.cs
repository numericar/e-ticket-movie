using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    [Route("[controller]")]
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        public async Task<ViewResult> Index()
        {
            var producers = await _producerService.GetAllAsync();
            return View("index", producers);
        }

        [HttpGet("{id}")]
        public async Task<ViewResult> Detail(int id)
        {
            var producer = await _producerService.GetByIdAsync(id);

            if (producer == null) return View("NotFound");

            return View(producer);
        }

        [HttpGet("create")]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _producerService.AddAsync(producer);
            await _producerService.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("edit/{id}")]
        public async Task<ViewResult> Edit(int id)
        {
            var producer = await _producerService.GetByIdAsync(id);

            if (producer == null) return View("NotFound");

            return View(producer);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("id, ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if (id != producer.Id) return View(producer);

            _producerService.UpdateAsync(producer);
            await _producerService.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}