using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JsonIssue.Authorization;

namespace JsonIssue
{
    [DependsOn(
        typeof(JsonIssueCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class JsonIssueApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<JsonIssueAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(JsonIssueApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
