using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    [Route("[controller]")]
    public class ProducerController : Controller
    {
        private readonly AppDbContext context;

        public ProducerController(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ViewResult> Index()
        {
            var producers = await this.context.Producers.ToListAsync();
            return View("index", producers);
        }
    }
}