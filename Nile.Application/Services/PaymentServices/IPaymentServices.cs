using Nile.Domain.EntityModel;

namespace Nile.Application.Services.PaymentServices
{
    public interface IPaymentServices
    {
        Task<Payment> GetPaymentById(int paymentId);
        Task<List<Payment>> GetAllPayment();
        Task<Payment> CreatePayment(Payment payment);
        Task DeletePayment(Payment payment);
        Task UpdatePayment(Payment payment);
    }
}