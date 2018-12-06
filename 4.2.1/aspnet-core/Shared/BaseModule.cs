using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Shared
{
    public abstract class BaseModule<TModule> : AbpModule 
        where TModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TModule).GetAssembly());
        }
    }
}
