using System.Threading.Tasks;
using JsonIssue.Configuration.Dto;

namespace JsonIssue.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
