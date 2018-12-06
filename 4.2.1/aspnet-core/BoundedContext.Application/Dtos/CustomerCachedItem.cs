using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoundedContext.Domain.ValueObjects;

namespace BoundedContext.Application.Dtos
{
    public class CustomerCachedItem
    {
        public int Id { get; set; }
        public LocalizedText Name { get; set; }
        public int Age { get; set; }
    }
}
