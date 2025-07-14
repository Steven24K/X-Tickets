using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly CmsXTicketsContext _context;

        public HomeController(CmsXTicketsContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            var events = _context.Events
                .Include(e => e.EventsVenueLnks)
                .ThenInclude(l => l.Venue)
                .Include(e => e.EventDateTimesEventLnks)
                .ThenInclude(l => l.EventDateTime)
                .Where(e => e.PublishedAt != null)
                .Select(e => new
                {
                    e.Id,
                    e.Title,
                    e.Description,
                    e.Price,
                    e.Slug,
                    e.PublishedAt,
                    Venue = e.EventsVenueLnks.Select(l => new
                    {
                        l.Venue.Name,
                        l.Venue.Capacity
                    }).FirstOrDefault(),
                    EventDateTimes = e.EventDateTimesEventLnks.Select(l => new
                    {
                        l.EventDateTime.DateTime,
                    }).ToList()
                })
                .ToList();
            return Ok(events);
        }
    }
}
