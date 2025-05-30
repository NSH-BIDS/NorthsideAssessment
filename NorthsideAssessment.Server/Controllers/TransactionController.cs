using Microsoft.AspNetCore.Mvc;
using NorthsideAssessment.Server.Services;
using NorthsideAssessment.Server.Shared.Models;
namespace NorthsideAssessment.Server.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _service;

        public TransactionController(TransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? department, [FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            var data = _service.GetTransactions(department, start, end);
            return Ok(data);
        }
    }
