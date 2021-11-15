using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Exceptions
{
    public class DomainRuleException : Exception
    {
        public DomainRuleException(string message) : base(message)
        {
        }

        public DomainRuleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainRuleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
