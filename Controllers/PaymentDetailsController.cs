using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Railway_Reservationsystem_WebAPI.Data;
using Railway_Reservationsystem_WebAPI.Models;

namespace Railway_Reservationsystem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly LoginDbContext _context;

        public PaymentDetailsController(LoginDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetpaymentDetailModels()
        {
            if (_context.paymentDetailModels == null)
            {
                return NotFound();
            }
            return await _context.paymentDetailModels.ToListAsync();
        }

        // GET: api/PaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            if (_context.paymentDetailModels == null)
            {
                return NotFound();
            }
            var paymentDetail = await _context.paymentDetailModels.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            if (_context.paymentDetailModels == null)
            {
                return Problem("Entity set 'LoginDbContext.paymentDetailModels'  is null.");
            }
            _context.paymentDetailModels.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.PaymentDetailId }, paymentDetail);
        }
        private bool PaymentDetailExists(int id)
        {
            return (_context.paymentDetailModels?.Any(e => e.PaymentDetailId == id)).GetValueOrDefault();
        }
    }
}
