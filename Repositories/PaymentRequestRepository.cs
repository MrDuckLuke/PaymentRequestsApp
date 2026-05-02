using Microsoft.EntityFrameworkCore;
using PaymentRequestsApp.Data;
using PaymentRequestsApp.Interfaces;
using PaymentRequestsApp.Models;

namespace PaymentRequestsApp.Repositories
{
    public class PaymentRequestRepository : IPaymentRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PaymentRequest>> GetAllAsync()
        {
            return await _context.PaymentRequests.ToListAsync();
        }

        public async Task AddAsync(PaymentRequest paymentRequest)
        {
            await _context.PaymentRequests.AddAsync(paymentRequest);
            await _context.SaveChangesAsync();
        }
    }
}
