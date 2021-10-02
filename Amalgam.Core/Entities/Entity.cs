using System;
using System.ComponentModel.DataAnnotations;

namespace Amalgam.Core.Entities
{
    public abstract class Entity
    {
        protected Entity() => Id = Guid.NewGuid();

        [Key]
        public Guid Id { get; private set; }
    }
}