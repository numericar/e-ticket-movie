using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    [Route("[controller]")]
    public class CinemaController : Controller
    {
        private readonly AppDbContext context;

        public CinemaController(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ViewResult> Index()
        {
            var cinemas = await this.context.Cinemas.ToListAsync();
            return View(cinemas);
        }
    }
}