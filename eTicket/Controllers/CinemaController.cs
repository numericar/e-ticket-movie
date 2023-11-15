using eTicket.Data;
using eTicket.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    [Route("[controller]")]
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<ViewResult> Index()
        {
            var cinemas = await _cinemaService.GetAllAsync();
            return View(cinemas);
        }
    }
}