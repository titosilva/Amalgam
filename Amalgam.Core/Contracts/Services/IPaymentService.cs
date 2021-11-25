using Amalgam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Contracts.Services
{
    public interface IPaymentService
    {
        void Pay(Payment payment);
    }
}
