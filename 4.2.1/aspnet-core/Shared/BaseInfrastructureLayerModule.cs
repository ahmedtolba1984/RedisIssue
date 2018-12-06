using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Microsoft.EntityFrameworkCore;

namespace Shared
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public abstract class BaseInfrastructureLayerModule<TModule, TContext> : 
        BaseModule<TModule>  
        where TModule : AbpModule
        where TContext : AbpDbContext
    {
        public bool SkipDbContextRegistration { get; set; }
        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<TContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        options.DbContextOptions.UseSqlServer(options.ExistingConnection);
                    }
                    else
                    {
                        options.DbContextOptions.UseSqlServer(options.ConnectionString);
                    }
                });
            }
            base.PreInitialize();
        }

        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
