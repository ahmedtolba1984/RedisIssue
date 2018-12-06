using Abp.AutoMapper;
using Abp.Events.Bus.Handlers;
using Abp.Modules;
using Castle.MicroKernel.Registration;

namespace Shared
{
    [DependsOn(
        typeof(AbpAutoMapperModule)
    )]
    public abstract class BaseApplicationLayerModule<TModule> :
        BaseModule<TModule>
        where TModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.ConventionalUowSelectors.Add(type => typeof(IAsyncEventHandler<>).IsAssignableFrom(type));
            base.PreInitialize();
        }

        public override void Initialize()
        {
            Configuration.IocManager.IocContainer.Register(Classes
                .FromAssemblyContaining<TModule>()
                .BasedOn(typeof(IAsyncEventHandler<>))
                .WithServiceSelf()
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            base.Initialize();
        }

    }
}
