using System.Threading.Tasks;
using Abp.Application.Services;
using JsonIssue.Sessions.Dto;

namespace JsonIssue.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
