using MAlib.Entity.Models._Obj;
using MAlib.Repository._Obj;
using MAServer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAServer.Controllers
{
    [ApiController]
    [Route("api/Obj")]
    public class ObjController : ControllerBase
    {
        private readonly ObjRepo _repo;

        public ObjController(ObjRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("Geral")]
        public async Task<IActionResult> GetGeralObj()
        {
            try
            {
                var obj = await _repo.GetObjGeral();

                if (obj == null || !obj.Any())
                {
                    return NoContent();
                }
                return Ok(obj);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
        [HttpGet("Specific")]
        public async Task<IActionResult> GetObjEsp()
        {
            try
            {
                var obj = await _repo.GetObjEsp();
                if (obj == null || !obj.Any())
                {
                    return NoContent();
                }
                return Ok(obj);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
