using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Amalgam.Core.Classes;

namespace Amalgam.Core.Entities
{
    public class GiftLink
    {
        public const int NameMaxLength = 50;

        public GiftLink()
        {
        }

        public GiftLink(string name, string url)
        {
            Name = name;
            Url = url;
        }

        [Required, MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required, MaxLength(Constants.UrlMaxLength)]
        public string Url { get; set; }
    }

    public class Gift : Entity
    {
        public const int NameMaxLen = 200;
        public const int DescriptionMaxLen = 2000;

        private Gift() : base() { }

        public Gift(string title, int value, string imageUrl = null, string description = null) : base()
        {
            Name = title;
            Value = value;
            ImageUrl = imageUrl;
            Links = new List<GiftLink>();
            Description = description;
        }


        [Required, MaxLength(NameMaxLen)]
        public string Name { get; private set; }

        [MaxLength(Constants.UrlMaxLength)]
        public string ImageUrl { get; private set; }

        public int Value { get; private set; }

        public Guid? PaymentId { get; private set; }

        public Payment Payment { get; private set; }

        public List<GiftLink> Links { get; private set; }

        [MaxLength(DescriptionMaxLen)]
        public string Description { get; private set; }

        #region Dates

        public DateTimeOffset? DateDeleted { get; private set; }

        #endregion

        #region  Setters

        public void SetTitle(string title) => Name = title;

        public void SetImageUrl(string imageUrl) => ImageUrl = imageUrl;

        public void SetValue(int value) => Value = value;

        public void SetPayment(Payment payment)
        {
            PaymentId = payment.Id;
            Payment = payment;
        }

        public void SetDateDeleted(DateTimeOffset date) => DateDeleted = date;

        public void SetDescription(string description) => Description = description;

        public void AddLink(string name, string url)
            => Links.Add(new GiftLink(name, url));

        public void AddMultipleLinks(IEnumerable<GiftLink> giftLinks)
            => Links.AddRange(giftLinks);

        public void ClearLinks()
            => Links = new List<GiftLink>();
        #endregion

        #region Getters
        [NotMapped]
        public bool IsDeleted => DateDeleted.HasValue;

        [NotMapped]
        public bool IsPaid => PaymentId.HasValue;
        #endregion
    }
}