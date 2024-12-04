using MAServer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAServer.Controllers
{
    [ApiController]
    [Route("api/Obj/[controller]")]
    public class ObjController : ControllerBase
    {
        private readonly MAContext _context;

        [HttpGet]
        public async Task<IActionResult> GetGeralObj()
        {
            var products = await _context.ObjEsp.ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ObjEsp objEsp)
        {
            _context.ObjEsp.Add(objEsp);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGeralObj), new { id = objEsp.Id }, objEsp);
        }
    }
}
