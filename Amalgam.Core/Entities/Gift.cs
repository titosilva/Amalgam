using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Amalgam.Core.Classes;

namespace Amalgam.Core.Entities
{
    public class Gift : Entity
    {
        public const int TitleMaxLen = 200;

        private Gift() : base() { }

        public Gift(string title, int value, string imageUrl = null) : base()
        {
            Title = title;
            Value = value;
            ImageUrl = imageUrl;
        }


        [Required, MaxLength(TitleMaxLen)]
        public string Title { get; private set; }

        [MaxLength(Constants.UrlMaxLength)]
        public string ImageUrl { get; private set; }

        public int Value { get; private set; }

        public Guid? PaymentId { get; private set; }

        public Payment Payment { get; private set; }

        #region Dates

        public DateTimeOffset? DateDeleted { get; private set; }

        #endregion

        #region  Setters

        public void SetTitle(string title) => Title = title;

        public void SetImageUrl(string imageUrl) => ImageUrl = imageUrl;

        public void SetValue(int value) => Value = value;

        public void SetPayment(Payment payment)
        {
            PaymentId = payment.Id;
            Payment = payment;
        }

        public void SetDateDeleted(DateTimeOffset date) => DateDeleted = date;

        #endregion

        #region Getters
        [NotMapped]
        public bool IsDeleted => DateDeleted.HasValue;

        [NotMapped]
        public bool IsPaid => PaymentId.HasValue;
        #endregion
    }
}