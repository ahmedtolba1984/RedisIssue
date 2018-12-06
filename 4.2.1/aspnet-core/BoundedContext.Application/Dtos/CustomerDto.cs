using System;
using Abp.Application.Services.Dto;

namespace BoundedContext.Application.Dtos
{
    public class CustomerDto : EntityDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}