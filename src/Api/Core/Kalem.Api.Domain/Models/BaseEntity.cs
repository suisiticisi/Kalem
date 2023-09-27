﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalem.Api.Domain.Models
{
    public class BaseEntity 
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Status { get; set; }

    }
}
