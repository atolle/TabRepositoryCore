﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabRepository.Models
{
    public class StripeSubscription
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }

        public string PlanId { get; set; }

        public string Status { get; set; }

        public bool CancelAtPeriodEnd { get; set; }

        public virtual StripeCustomer Customer { get; set; }

        public virtual StripePlan Plan { get; set; }
    }

    public enum SubscriptionStatus
    {
        Active,
        Canceled,
        CancelAtPeriodEnd,
        None
    }
}
