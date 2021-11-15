using Amalgam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Contracts.Repositories
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);
        void UpdatePayment(Payment payment);
    }
}
