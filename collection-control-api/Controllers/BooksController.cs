using collection_control_api.Entities;
using collection_control_api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collection_control_api.Controllers
{
    [Route("api/Books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            if (id < 1) return NotFound();

            var book = _bookService.GetById(id);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book newBook)
        {
            if (newBook == null) return BadRequest();

            _bookService.Create(newBook);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book updateBook)
        {
            if (updateBook == null) return BadRequest();

            _bookService.Update(updateBook);

            return NoContent();
        }
    }
}
