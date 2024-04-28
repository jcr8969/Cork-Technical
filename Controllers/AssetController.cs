using Cork_Technical.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cork_Technical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {

        private readonly ApiDbContext _context;

        public AssetController(ApiDbContext context)
        {
            _context = context;
        }

    }
}
