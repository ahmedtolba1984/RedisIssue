using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using BoundedContext.Application.Dtos;
using BoundedContext.Domain.Aggregates;
using BoundedContext.Domain.ValueObjects;

namespace BoundedContext.Application
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private const string CustomerCache = "CustomerCache";
        private const string CustomerCacheKey = "CustomerCacheKey";

        private readonly IRepository<Customer> _customerRepository;
        private readonly ICacheManager _cacheManager;

        public CustomerAppService(IRepository<Customer> customerRepository,
            ICacheManager cacheManager)
        {
            _customerRepository = customerRepository;
            _cacheManager = cacheManager;
        }

        public async Task CreateOrUpdateCustomer(CustomerDto input)
        {
            if (input.Id <= 0)
            {
                await CreateCustomerAsync(input);
            }
            else
            {
                await UpdateCustomerAsync(input);
            }
        }

        private async Task UpdateCustomerAsync(CustomerDto input)
        {
            var customer = await _customerRepository.GetAsync(input.Id);
            if (customer != null)
            {
                customer.Name = new LocalizedText(input.Name);
                customer.Age = input.Age;
            }
        }

        private async Task CreateCustomerAsync(CustomerDto input)
        {
            var customer = new Customer(new LocalizedText(input.Name), input.Age);
            await _customerRepository.InsertAsync(customer);
        }

        public async Task<CustomerDto> GetCustomerForEdit(NullableIdDto input)
        {
            var customer = await _customerRepository.GetAsync(input.Id.Value);
            if (customer != null)
            {
                return new CustomerDto
                {
                    Id = customer.Id,
                    Name = customer.Name.StringValue,
                    Age = customer.Age
                };

            }
            return new CustomerDto();
        }

        public async Task<ListResultDto<CustomerListDto>> GetCustomers()
        {
            var cache = _cacheManager.GetCache(CustomerCache);
            var cachedData = await cache.GetOrDefaultAsync(CustomerCacheKey);
            if (cachedData == null)
            {
                var customers = await _customerRepository.GetAllListAsync();
                cachedData = new List<CustomerCachedItem>
                    (customers.Select(x => new CustomerCachedItem
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Age = x.Age
                    }));

                await cache.SetAsync(CustomerCacheKey, cachedData);
            }
            return MapFromCachedDataToDtos((IList<CustomerCachedItem>)cachedData);
        }

        private ListResultDto<CustomerListDto> MapFromCachedDataToDtos(IList<CustomerCachedItem> customerCachedItems)
        {
            return new ListResultDto<CustomerListDto>(customerCachedItems.Select(x => new CustomerListDto
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age
            }).ToList());
        }
    }
}
