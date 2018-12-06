using Abp.Modules;
using BoundedContext.Application;
using Shared;

namespace BoundedContext.Infrastructure
{
    [DependsOn(
        typeof(BoundedContextApplicationModule)
    )]
    public class BoundedContextInfrastructureModule
        : BaseInfrastructureLayerModule<BoundedContextInfrastructureModule, CustomerDbContext>
    {
    }
}
