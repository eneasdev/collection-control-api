using collection_control_api.Entities;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace collection_control_api.Controllers
{
    [Route("api/Dvds")]
    public class DvdsController : ControllerBase
    {
        private readonly IDvdRepository _dvdService;
        public DvdsController(IDvdRepository dvdService)
        {
            _dvdService = dvdService;
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            if (id < 1) return NotFound();

            var dvd = _dvdService.GetById(id);

            return Ok(dvd);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Dvd newDvd)
        {
            if (newDvd == null) return BadRequest();

            _dvdService.Create(newDvd);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Dvd updateDvd)
        {
            if (updateDvd == null) return BadRequest();

            _dvdService.Update(updateDvd);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 1) return NotFound();

            _dvdService.Delete(id);

            return NoContent();
        }
    }
}
