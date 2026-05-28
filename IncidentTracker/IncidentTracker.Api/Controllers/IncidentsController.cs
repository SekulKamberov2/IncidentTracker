namespace IncidentTracker.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using IncidentTracker.Api.DTOs;
    using IncidentTracker.Api.Services;
 
    [ApiController]
    [Route("api/incidents")]
    public class IncidentsController : ControllerBase
    {
        private readonly IncidentService _service;
        public IncidentsController(IncidentService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Create(CreateIncidentRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Title))
                return BadRequest("Title required");

            return Ok(await _service.Create(req.Title));
        }

        [HttpPost("{id}/resolve")]
        public async Task<IActionResult> Resolve(string id)
        {
            var ok = await _service.Resolve(id);
            return ok ? Ok() : NotFound();
        }
    }
}
