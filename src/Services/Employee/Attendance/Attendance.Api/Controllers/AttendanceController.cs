using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Attendance.Application.Domain;
using Attendance.Application.Features.Attendance.Commands;
using Attendance.Application.Features.Attendance.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Attendance.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AttendanceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AttendanceController> _logger;

        public AttendanceController(ILogger<AttendanceController> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(mediator));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("[action]", Name = "PunchIn")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> PunchIn([FromBody] int employeeId)
        {
            _logger.LogInformation("request for PunchIn");

            var command = new PunchInCommand(employeeId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [Route("[action]", Name = "PunchOut")]
        [HttpPut]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> PunchOut([FromBody] int employeeId)
        {
            _logger.LogInformation("request for PunchOut");

            var command = new PunchOutCommand(employeeId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{employeeId}", Name = "GetAttendance")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<EmployeeAttendance>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<EmployeeAttendance>>> GetAttendance(int employeeId)
        {
            if (employeeId == 0)
            {
                _logger.LogInformation("employee id is null");
                return BadRequest();
            }

            _logger.LogInformation("request for employee month wise attendance records with specific id");

            var query = new AttendanceQuery(employeeId);
            var employees = await _mediator.Send(query);

            if(!employees.Any())
            {
                _logger.LogInformation("No employee found with this id");

                return NotFound();
            }

            return Ok(employees);
        }
    }
}
