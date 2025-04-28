using GreenGrocerLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreenGrocerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduceController : ControllerBase
    {
        private readonly IProduceRepository _produceRepository;

        public ProduceController(IProduceRepository produceRepository)
        {
            this._produceRepository = produceRepository;
        }

        // GET: api/<ProduceController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var produceList = this._produceRepository.GetAll();

            if ( produceList == null)
            { 
                return NoContent();
            }

            return Ok(produceList);
        }

        // GET api/<ProduceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProduceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProduceController>/5
        [HttpPut("{barcode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int barcode, [FromBody] UpdateProduceDTO value)
        {


            var produceToUpdate = _produceRepository.Update(barcode, value);

            if (produceToUpdate == null)
            { 
                return NotFound();
            }

            return Ok(produceToUpdate);
        }

        // DELETE api/<ProduceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
