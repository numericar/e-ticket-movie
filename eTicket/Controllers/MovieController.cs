using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly AppDbContext context;

        public MovieController(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ViewResult> Index()
        {
            var movies = await this.context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
            return View(movies);
        }
    }
}