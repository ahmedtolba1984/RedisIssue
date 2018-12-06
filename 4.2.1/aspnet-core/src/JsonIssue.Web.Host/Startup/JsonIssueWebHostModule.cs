using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JsonIssue.Configuration;

namespace JsonIssue.Web.Host.Startup
{
    [DependsOn(
       typeof(JsonIssueWebCoreModule))]
    public class JsonIssueWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public JsonIssueWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JsonIssueWebHostModule).GetAssembly());
        }
    }
}
