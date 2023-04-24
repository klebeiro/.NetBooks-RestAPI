using AspNetRest.Business;
using AspNetRest.Data.VO;
using Microsoft.AspNetCore.Mvc;

namespace AspNetRest.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        private IBooksBusiness _booksBusiness;

        public BooksController(IBooksBusiness booksBusiness)
        {
            _booksBusiness = booksBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _booksBusiness.FindByID(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BooksVO book)
        {
            if (book == null) return BadRequest();
            return Ok(_booksBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] BooksVO book)
        {
            if (book == null) return BadRequest();
            return Ok(_booksBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }
    }
}
