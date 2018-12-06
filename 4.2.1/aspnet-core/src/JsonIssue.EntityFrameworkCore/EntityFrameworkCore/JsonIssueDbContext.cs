using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using JsonIssue.Authorization.Roles;
using JsonIssue.Authorization.Users;
using JsonIssue.MultiTenancy;

namespace JsonIssue.EntityFrameworkCore
{
    public class JsonIssueDbContext : AbpZeroDbContext<Tenant, Role, User, JsonIssueDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public JsonIssueDbContext(DbContextOptions<JsonIssueDbContext> options)
            : base(options)
        {
        }
    }
}
