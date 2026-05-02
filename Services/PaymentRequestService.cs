using PaymentRequestsApp.Interfaces;
using PaymentRequestsApp.Models;

namespace PaymentRequestsApp.Services
{
    public class PaymentRequestService : IPaymentRequestService
    {
        private readonly IPaymentRequestRepository _repository;

        public PaymentRequestService(IPaymentRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PaymentRequest>> GetAllPaymentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PaymentRequest> CreatePaymentAsync(PaymentRequest request) 
        { 
            await _repository.AddAsync(request);
            return request;
        }
    }
}
