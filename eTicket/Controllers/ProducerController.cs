using eTicket.Data.Services;
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
    }
}