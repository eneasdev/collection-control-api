using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace collection_control_api.Controllers
{
    [Route("api/Cds")]
    public class CdsController : ControllerBase
    {
        private readonly ICdRepository _cdRepository;
        public CdsController(ICdRepository cdRepository)
        {
            _cdRepository = cdRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 1) return BadRequest();

            var cd = _cdRepository.GetById(id);

            if (cd == null) return NotFound();

            return Ok(cd);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewCdInputModel newCdInputModel)
        {
            if (newCdInputModel == null) return BadRequest();

            _cdRepository.Create(newCdInputModel);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateItemInputModel updateCdInputModel)
        {
            if (updateCdInputModel == null) return BadRequest();

            _cdRepository.Update(updateCdInputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 1) return NotFound();

            _cdRepository.Delete(id);

            return NoContent();
        }
    }
}
