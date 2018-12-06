using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JsonIssue.Roles.Dto;
using JsonIssue.Users.Dto;

namespace JsonIssue.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
