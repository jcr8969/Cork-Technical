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


        // UPDATE by id
        [HttpPost("Update")]
        public JsonResult Post(int id,  Asset asset)
        {
            if (id != asset.id)
                return new JsonResult(NotFound());

            _context.Entry(asset).State = EntityState.Modified;
            _context.SaveChanges();

            return new JsonResult(Ok(asset));
        }


        // GET filtered by type
        [HttpGet("FilterByType")]
        public JsonResult Get(string type)
        {
            try
            {
                var result = _context.Assets.Where(a => a.type == type).ToList();

                if (result.Count == 0)
                    return new JsonResult(NotFound());

                return new JsonResult(Ok(result));
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
    }
}
