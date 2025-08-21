using Microsoft.AspNetCore.Mvc;
using HumanWebApiApp.Model;
using Microsoft.AspNetCore.Connections.Features;
using HumanWebApiApp.Repository;
using HumanWebApiApp.DTO;


namespace HumanWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanRepository humanRepository;
        private readonly ILogger<HumanController> logger;
        public HumanController(ILogger<HumanController> _logger, IHumanRepository _humanRepository)
        {
            humanRepository = _humanRepository;
            logger = _logger;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<HumanReadDTO>> GetAllHumans()
        {
            logger.LogInformation("GetAllHumans activated!");
            var hmns = humanRepository.GetAllHumans();
            var readHmns = hmns.Select(x => new HumanReadDTO()
            {
                id = x.id,
                firstName = x.firstName,
                secondName = x.secondName,
                citizenship = x.citizenship,
                email = x.email
            });

            return Ok(readHmns);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Human> GetByIdHuman(int id)
        {
            if (id <= 0)
            {
                logger.LogError("GetByIdHuman error!");
                return BadRequest(new ErrorResponse()
                {
                    Error = "Wrong ID input",
                    Details = "ID should be bigger than 0!"
                });
            }
            var hn = humanRepository.GetByIdHuman(id);
            if (hn is null)
            {
                logger.LogWarning("GetByIdHuman warning!");
                return NotFound(new ErrorResponse()
                {
                    Error = "No person was found",
                    Details = $"There is no information about a person with id: {id}"
                });
            }
            var hnRead = new HumanReadDTO()
            {
                id = hn.id,
                firstName = hn.firstName,
                secondName = hn.secondName,
                citizenship = hn.citizenship,
                email = hn.email
            };

            return Ok(hnRead);
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<HumanReadDTO> AddNewHuman([FromBody] HumanCreateDTO human)
        {

            if (human is null)
                return BadRequest(new ErrorResponse()
                {
                    Error = "Human object is null",
                    Details = $"There is no data transferred to object: {human.GetType()}"
                });

            var hn = humanRepository.AddNewHuman(human);

            var readHuman = new HumanReadDTO()
            {
                id = hn.id,
                firstName = hn.firstName,
                secondName = hn.secondName,
                citizenship = hn.citizenship,
                email = hn.email
            };

            return CreatedAtAction(nameof(GetByIdHuman), new { id = readHuman.id }, readHuman);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteByIdHuman([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new ErrorResponse()
                {
                    Error = "Wrong ID input",
                    Details = "ID should be bigger than 0!"
                });

            if (!humanRepository.DeleteByIdHuman(id))
                return NotFound(new ErrorResponse()
                {
                    Error = "No person was found",
                    Details = $"There is no information about a person with id: {id}"
                });

            return NoContent();
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<HumanUpdateDTO> UpdateHumanById([FromRoute] int id, [FromBody] HumanUpdateDTO newHuman)
        {
            if (id <= 0)
                return BadRequest(new ErrorResponse()
                {
                    Error = "Wrong ID input",
                    Details = "ID should be bigger than 0!"
                });

            var personHuman = new Human()
            {
                firstName = newHuman.firstName,
                secondName = newHuman.secondName,
                citizenship = newHuman.citizenship
            };

            var person = humanRepository.UpdateHumanById(id, personHuman);

            if (person is null) 
                return NotFound(new ErrorResponse()
                {
                    Error = "No person was found",
                    Details = $"There is no information about a person with id: {id}"
                });

            var personRead = new HumanReadDTO()
            {
                id = person.id,
                firstName = person.firstName,
                secondName = person.secondName,
                citizenship = person.citizenship,
                email = person.email
            };

            return CreatedAtAction(nameof(GetByIdHuman), new { id = personRead.id }, personRead);
        }

    }
}
