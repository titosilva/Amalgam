using Amalgam.Core.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Entities
{
    public class Payment : Entity
    {
        #region Payer
        [MaxLength(200)]
        public string PayerName { get; private set; }

        [MaxLength(Constants.EmailMaxLength)]
        public string PayerEmail { get; private set; }

        [MaxLength(Constants.MobileMaxLength)]
        public string PayerMobile { get; private set; }
        #endregion

        #region Target
        public string TargetName { get; private set; }

        public Guid? TargetId { get; private set; }

        public int Amount { get; private set; }
        #endregion

        #region Setters
        public void SetPayer(string name, string email = null, string mobile = null)
        {
            PayerName = name;
            PayerEmail = email;
            PayerMobile = mobile;
        }

        public void SetTarget(Gift gift)
        {
            TargetName = $"Presente para João Tito e Isabelle - {gift.Name}";
            TargetId = gift.Id;
            Amount = gift.Value;
        }

        public void SetTarget(string targetName, int amount, Guid? targetId = null)
        {
            TargetName = targetName;
            Amount = amount;
        }
        #endregion
    }
}
