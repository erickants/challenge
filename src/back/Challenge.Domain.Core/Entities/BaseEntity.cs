using System;

namespace src.back.Challenge.Domain.Core.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; private set;}
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}