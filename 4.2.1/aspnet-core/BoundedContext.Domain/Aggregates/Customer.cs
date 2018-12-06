using System;
using Abp.Domain.Entities.Auditing;
using BoundedContext.Domain.ValueObjects;

namespace BoundedContext.Domain.Aggregates
{
    public class Customer : FullAuditedAggregateRoot
    {
        public Customer()
        {
            
        }

        public Customer(LocalizedText name, int age)
        {
            Name = name;
            Age = age;
        }

        public LocalizedText Name { get; set; }
        public int Age { get; set; }
    }
}
