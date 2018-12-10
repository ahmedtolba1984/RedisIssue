using Abp.Events.Bus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.EntityHistory;
using Abp.Events.Bus.Entities;
using BoundedContext.Domain.Aggregates;

namespace BoundedContext.Application
{
    public class CustomerChangedEventHandler : IAsyncEventHandler<EntityChangedEventData<Customer>>
    {
        public async Task HandleEventAsync(EntityChangedEventData<Customer> eventData)
        {
            var test = "asdads";
        }
    }
}
