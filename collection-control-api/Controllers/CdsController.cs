using collection_control_api.Entities;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace collection_control_api.Controllers
{
    [Route("api/Cds")]
    public class CdsController : ControllerBase
    {
        private readonly ICdRepository _cdService;
        public CdsController(ICdRepository cdService)
        {
            _cdService = cdService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 1) return BadRequest();

            var cd = _cdService.GetById(id);

            if (cd == null) return NotFound();

            return Ok(cd);
        }

        [HttpPost]
        public IActionResult Create(Cd newCd)
        {
            if (newCd == null) return BadRequest();

            _cdService.Create(newCd);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Cd updateCd)
        {
            if (updateCd == null) return BadRequest();

            _cdService.Update(updateCd);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 1) return NotFound();

            _cdService.Delete(id);

            return NoContent();
        }
    }
}
