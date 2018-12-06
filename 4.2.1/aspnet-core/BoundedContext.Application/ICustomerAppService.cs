using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BoundedContext.Application.Dtos;

namespace BoundedContext.Application
{
    public interface ICustomerAppService: IApplicationService
    {
        Task CreateOrUpdateCustomer(CustomerDto input);
        Task<CustomerDto> GetCustomerForEdit(NullableIdDto input);
        Task<ListResultDto<CustomerListDto>> GetCustomers();
    }
}