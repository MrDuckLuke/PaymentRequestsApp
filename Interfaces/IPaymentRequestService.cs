using PaymentRequestsApp.Models;

namespace PaymentRequestsApp.Interfaces
{
    public interface IPaymentRequestService
    {
        Task<IEnumerable<PaymentRequest>> GetAllPaymentsAsync();
        Task<PaymentRequest> CreatePaymentAsync(PaymentRequest request);
    }
}
