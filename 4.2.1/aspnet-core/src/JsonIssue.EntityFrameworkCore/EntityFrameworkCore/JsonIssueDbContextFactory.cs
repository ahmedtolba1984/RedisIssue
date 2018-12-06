using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using JsonIssue.Configuration;
using JsonIssue.Web;

namespace JsonIssue.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class JsonIssueDbContextFactory : IDesignTimeDbContextFactory<JsonIssueDbContext>
    {
        public JsonIssueDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JsonIssueDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            JsonIssueDbContextConfigurer.Configure(builder, configuration.GetConnectionString(JsonIssueConsts.ConnectionStringName));

            return new JsonIssueDbContext(builder.Options);
        }
    }
}
