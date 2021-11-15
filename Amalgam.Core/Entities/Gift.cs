using System;
using System.ComponentModel.DataAnnotations;
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

        #region Dates

        public DateTimeOffset? DateDeleted { get; private set; }

        #endregion

        #region  Setters

        public void SetTitle(string title) => Title = title;

        public void SetImageUrl(string imageUrl) => ImageUrl = imageUrl;

        public void SetValue(int value) => Value = value;

        public void SetDateDeleted(DateTimeOffset date) => DateDeleted = date;

        #endregion

        #region Getters
        public bool IsDeleted => DateDeleted.HasValue;
        #endregion
    }
}