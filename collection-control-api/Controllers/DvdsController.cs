﻿using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id < 1) return BadRequest();

            var dvd = _dvdService.GetById(id);

            if (dvd == null) return NotFound();

            return Ok(dvd);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewDvdInputModel newDvd)
        {
            if (newDvd == null) return BadRequest();

            _dvdService.Create(newDvd);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateItemInputModel updateDvdInputModel)
        {
            if (updateDvdInputModel == null) return BadRequest();

            _dvdService.Update(updateDvdInputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 1) return NotFound();

            _dvdService.Delete(id);

            return NoContent();
        }
    }
}
