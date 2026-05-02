using PaymentRequestsApp.Models;

namespace PaymentRequestsApp.Interfaces
{
    public interface IPaymentRequestRepository
    {
        Task<IEnumerable<PaymentRequest>> GetAllAsync();
        Task AddAsync(PaymentRequest paymentRequest);
    }
}
