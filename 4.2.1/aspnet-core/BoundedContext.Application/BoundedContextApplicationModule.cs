using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Modules;
using BoundedContext.Domain;
using Shared;

namespace BoundedContext.Application
{
    [DependsOn(
        typeof(BoundedContextDomainModule)
    )]
    public class BoundedContextApplicationModule :
        BaseApplicationLayerModule<BoundedContextApplicationModule>
    {

    }
}
