using collection_control_api.Entities;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Controllers
{
    public class DvdsController : ControllerBase
    {
        private readonly IDvdService _dvdService;
        public DvdsController(IDvdService dvdService)
        {
            _dvdService = dvdService;
        }
        public IActionResult GetById(int id)
        {
            if (id < 1) return NotFound();

            var dvd = _dvdService.GetById(id);

            return Ok(dvd);
        }

        public IActionResult Create([FromBody] Dvd newDvd)
        {
            if (newDvd == null) return BadRequest();

            _dvdService.Create(newDvd);

            return Ok();
        }

        public IActionResult Update([FromBody] Dvd updateDvd)
        {
            if (updateDvd == null) return BadRequest();

            _dvdService.Update(updateDvd);

            return NoContent();
        }

        public IActionResult Delete(int id)
        {
            if (id < 1) return NotFound();

            _dvdService.Delete(id);

            return NoContent();
        }
    }
}
