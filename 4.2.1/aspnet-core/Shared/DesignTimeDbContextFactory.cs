using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Shared
{
    public abstract class DesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
        where TContext : AbpDbContext
    {
        public TContext CreateDbContext(string[] args)
        {
            var configuration = Configurations.Get(Directory.GetCurrentDirectory(), addUserSecrets: false);
            var builder = new DbContextOptionsBuilder<TContext>();
            DbContextConfigurer.Configure(builder, configuration.GetConnectionString(Constants.ConnectionStringName));
            var dbContext = (TContext)Activator.CreateInstance(typeof(TContext), builder.Options);
            return dbContext;
        }
    }
}
