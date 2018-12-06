using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shared
{
    public static class DbContextConfigurer
    {
        public static void Configure<TContext>(DbContextOptionsBuilder<TContext> builder, string connectionString) where TContext : AbpDbContext
        {
            builder
                .UseSqlServer(connectionString);
        }

        public static void Configure<TContext>(DbContextOptionsBuilder<TContext> builder, DbConnection connection) where TContext : AbpDbContext
        {
            builder
                .UseSqlServer(connection);
        }


    }

}
