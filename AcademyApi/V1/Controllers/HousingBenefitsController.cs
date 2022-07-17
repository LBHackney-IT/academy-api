using System.Collections.Generic;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.UseCase.Interfaces;
using Hackney.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AcademyApi.V1.Controllers
{
    [ApiController]
    [Route("api/v1/benefits")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class HousingBenefitsController : BaseController
    {
        private readonly IHousingBenefitsSearchUseCase _housingBenefitsSearchUseCase;
        private readonly IGetHousingBenefitsNotesUseCase _getHousingBenefitsNotesUseCase;

        public HousingBenefitsController(IHousingBenefitsSearchUseCase housingBenefitsSearchUseCase, IGetHousingBenefitsNotesUseCase getHousingBenefitsNotesUseCase)
        {
            _housingBenefitsSearchUseCase = housingBenefitsSearchUseCase;
            _getHousingBenefitsNotesUseCase = getHousingBenefitsNotesUseCase;
        }

        /// <summary>
        /// ...
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">No results found </response>
        [ProducesResponseType(typeof(SearchResponseObjectList), StatusCodes.Status200OK)]
        [HttpGet]
        [LogCall(LogLevel.Information)]
        [Route("search")]
        public IActionResult Search([FromQuery] string firstName, string lastName)
        {
            return Ok(_housingBenefitsSearchUseCase.Execute(firstName, lastName).Result);
        }

        /// <summary>
        /// ...
        /// </summary>
        /// <response code="200">...</response>
        /// <response code="404">No ? found for the specified ID</response>
        [ProducesResponseType(typeof(BenefitsResponseObject), StatusCodes.Status200OK)]
        [HttpGet]
        [LogCall(LogLevel.Information)]
        //TODO: rename to match the identifier that will be used
        [Route("{benefitsId}")]
        public IActionResult ViewRecord(int benefitsId)
        {
            return Ok(new BenefitsResponseObject());
        }


        /// <summary>
        /// ...
        /// </summary>
        /// <response code="200">...</response>
        /// <response code="404">No notes found for the specified ID</response>
        [ProducesResponseType(typeof(List<NoteResponseObject>), StatusCodes.Status200OK)]
        [HttpGet]
        [LogCall(LogLevel.Information)]
        //TODO: rename to match the identifier that will be used
        [Route("{claimId}/notes")]
        public IActionResult GetNotes(int claimId)
        {
            return Ok(_getHousingBenefitsNotesUseCase.Execute(claimId).Result);

        }
    }
}
