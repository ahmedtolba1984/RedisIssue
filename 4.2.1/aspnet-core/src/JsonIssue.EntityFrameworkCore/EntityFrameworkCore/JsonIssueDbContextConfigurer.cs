using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace JsonIssue.EntityFrameworkCore
{
    public static class JsonIssueDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<JsonIssueDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<JsonIssueDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
