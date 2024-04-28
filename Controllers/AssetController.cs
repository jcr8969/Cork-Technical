using Cork_Technical.Data;
using Cork_Technical.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        // GetAll
        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.Assets.ToList();
            return new JsonResult(Ok(result));
        }

        // POST
        [HttpPost]
        public JsonResult Post(Asset asset)
        {
            _context.Assets.Add(asset);
            _context.SaveChanges();

            return new JsonResult(Ok(asset));
        }

        // GET by id
        [HttpGet("/id")]
        public JsonResult Get(int id)
        {
            var result = _context.Assets.Find(id);

            if(result == null)
                return new JsonResult(NotFound());
            
            return new JsonResult(Ok(result));
        }

        // DELETE
        [HttpDelete("/id")]
        public JsonResult Delete(int id) 
        {
            var result = _context.Assets.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Assets.Remove(result);
            _context.SaveChanges();

            return new JsonResult(Ok(result));
        }

    }
}
