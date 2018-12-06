using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace JsonIssue.Controllers
{
    public abstract class JsonIssueControllerBase: AbpController
    {
        protected JsonIssueControllerBase()
        {
            LocalizationSourceName = JsonIssueConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
