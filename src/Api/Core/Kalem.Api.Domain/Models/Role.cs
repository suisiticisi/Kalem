﻿namespace Kalem.Api.Domain.Models
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
      
    }
}


