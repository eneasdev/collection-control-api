using collection_control_api.Entities;
using collection_control_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace collection_control_api.Controllers
{
    [Route("api/Books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookService;
        public BooksController(IBookRepository bookService)
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

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0) return NotFound();

            _bookService.Delete(id);

            return NoContent();
        }
    }
}
