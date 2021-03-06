using System;
using System.Collections.Generic;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.UseCase.Interfaces;
using Hackney.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AcademyApi.V1.Controllers
{
    [ApiController]
    //TODO: Rename to match the APIs endpoint
    [Route("api/v1/council-tax")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    //TODO: rename class to match the API name
    public class CouncilTaxController : BaseController
    {
        private readonly ICouncilTaxSearchUseCase _councilTaxSearchUseCase;
        private readonly IGetCouncilTaxCustomerUseCase _getCouncilTaxCustomerUseCase;
        private readonly IGetCouncilTaxNotesUseCase _getCouncilTaxNotesUseCase;

        public CouncilTaxController(ICouncilTaxSearchUseCase councilTaxSearchUseCase, IGetCouncilTaxCustomerUseCase getCouncilTaxCustomerUseCase, IGetCouncilTaxNotesUseCase getCouncilTaxNotesUseCase)
        {
            _councilTaxSearchUseCase = councilTaxSearchUseCase;
            _getCouncilTaxCustomerUseCase = getCouncilTaxCustomerUseCase;
            _getCouncilTaxNotesUseCase = getCouncilTaxNotesUseCase;
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
            var result = _councilTaxSearchUseCase.Execute(firstName, lastName).Result;
            return Ok(result);
        }

        /// <summary>
        /// ...
        /// </summary>
        /// <response code="200">...</response>
        /// <response code="404">No ? found for the specified ID</response>
        [ProducesResponseType(typeof(CouncilTaxRecord), StatusCodes.Status200OK)]
        [HttpGet]
        [LogCall(LogLevel.Information)]
        //TODO: rename to match the identifier that will be used
        [Route("{councilTaxId}")]
        public IActionResult ViewRecord(int councilTaxId)
        {
            return Ok(_getCouncilTaxCustomerUseCase.Execute(councilTaxId).Result);
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
        [Route("{councilTaxId}/notes")]
        public IActionResult GetNotes(int councilTaxId)
        {
            return Ok(_getCouncilTaxNotesUseCase.Execute(councilTaxId).Result);

        }
    }
}
