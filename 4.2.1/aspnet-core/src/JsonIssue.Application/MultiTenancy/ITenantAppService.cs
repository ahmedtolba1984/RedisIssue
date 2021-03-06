﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JsonIssue.MultiTenancy.Dto;

namespace JsonIssue.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
