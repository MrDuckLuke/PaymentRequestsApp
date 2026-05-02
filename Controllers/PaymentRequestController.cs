using Microsoft.AspNetCore.Mvc;
using PaymentRequestsApp.Interfaces;
using PaymentRequestsApp.Models;

namespace PaymentRequestApp.Controllers
{
    [ApiController]
    [Route("api/payment-requests")]
    public class PaymentRequestController : Controller
    {
        private readonly IPaymentRequestService _service;

        public PaymentRequestController(IPaymentRequestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _service.GetAllPaymentsAsync();
            return Ok(payments);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreatePaymentAsync(request);

            return CreatedAtAction(nameof(GetAll), new { id = created.ID, created });
        }
    }
}