﻿using collection_control_api.Entities;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace collection_control_api.Controllers
{
    [Route("api/Cds")]
    public class CdsController : ControllerBase
    {
        private readonly ICdService _cdService;
        public CdsController(ICdService cdService)
        {
            _cdService = cdService;
        }
        public IActionResult Create([FromBody] Cd newCd)
        {
            if (newCd == null) return BadRequest();

            _cdService.Create(newCd);

            return Ok();
        }

        public IActionResult Update([FromBody] Cd updateCd)
        {
            if (updateCd == null) return BadRequest();

            _cdService.Update(updateCd);

            return NoContent();
        }

        public IActionResult Delete(int id)
        {
            if (id < 1) return NotFound();

            _cdService.Delete(id);

            return NoContent();
        }
    }
}
