﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabRepository.Models
{
    public class StripeProduct
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<StripePlan> Plans { get; set; }
    }
}
