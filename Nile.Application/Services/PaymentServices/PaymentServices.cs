
using Microsoft.EntityFrameworkCore;
using Nile.Domain.EntityModel;
using Nile.Infrastructure.Context;

namespace Nile.Application.Services.PaymentServices
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IApplicationDbContext _context;

        public PaymentServices(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            try
            {
                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();
                return payment;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeletePayment(Payment payment)
        {
            try
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Payment>> GetAllPayment()
        {
            try
            {
                List<Payment> payments = await _context.Payments.ToListAsync();
                return payments;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Payment> GetPaymentById(int paymentId)
        {
            try
            {
                Payment payment = await _context.Payments
                                    .Where(payment => payment.PaymentId == paymentId)
                                    .FirstOrDefaultAsync();
                return payment;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdatePayment(Payment payment)
        {
            try
            {
                _context.Payments.Update(payment);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
