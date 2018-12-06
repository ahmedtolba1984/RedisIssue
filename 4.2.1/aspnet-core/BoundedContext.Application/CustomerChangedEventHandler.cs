using Abp.Events.Bus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.EntityHistory;
using Abp.Events.Bus.Entities;

namespace BoundedContext.Application
{
    public class CustomerChangedEventHandler : IAsyncEventHandler<EntityChangedEventData<Entity<int>>>
    {
        public async Task HandleEventAsync(EntityChangedEventData<Entity<int>> eventData)
        {

        }
    }
}
