using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Students.Infra.Data.Sql
{
    public static class ContextFactory
    {
        public static Context GetSqlContext()
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlServer("Server=.;Database=StudentBromand;Integrated Security=true;TrustServerCertificate=true;",c=>c.UseQuerySplittingBehavior( QuerySplittingBehavior.SplitQuery))
                .LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information);
            return new Context(builder.Options);
        }
    }
}