using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using JsonIssue.Configuration.Dto;

namespace JsonIssue.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : JsonIssueAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
