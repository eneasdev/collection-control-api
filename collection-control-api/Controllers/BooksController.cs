using collection_control_api.Entities;
using collection_control_api.Interfaces;
using collection_control_api.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace collection_control_api.Controllers
{
    [Route("api/Books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            if (id < 1) return NotFound();

            var book = _bookRepository.GetById(id);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewBookInputModel newBookInputModel)
        {
            if (newBookInputModel == null) return BadRequest();

            _bookRepository.Create(newBookInputModel);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Book updateBook)
        {
            if (updateBook == null) return BadRequest();

            _bookRepository.Update(updateBook);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0) return NotFound();

            _bookRepository.Delete(id);

            return NoContent();
        }
    }
}
