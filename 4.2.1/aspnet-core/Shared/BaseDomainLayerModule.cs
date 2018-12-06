using Abp.Modules;

namespace Shared
{
    public abstract class BaseDomainLayerModule<TModule> : BaseModule<TModule>
        where TModule : AbpModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
        }
    }
}
