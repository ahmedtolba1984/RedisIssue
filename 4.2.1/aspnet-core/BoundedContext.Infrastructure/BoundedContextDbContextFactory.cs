using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shared;

namespace BoundedContext.Infrastructure
{
    public class BoundedContextDbContextFactory : DesignTimeDbContextFactory<CustomerDbContext>
    {
        
    }
}
