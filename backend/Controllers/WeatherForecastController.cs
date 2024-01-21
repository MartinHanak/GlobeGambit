using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly BackendDbContext _context;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, BackendDbContext context)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<TestProduct>> GetProduct(int id)
        {
            return await _context.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<IEnumerable<TestProduct>> PostProduct(int id)
        {
            return await _context.Products.ToListAsync();
        }
    }
}