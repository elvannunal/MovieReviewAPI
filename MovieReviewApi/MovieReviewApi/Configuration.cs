using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.Concrete;

namespace MovieReviewApi;

public class RepositoryContextFactory
    : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        // configurationBuilder
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // DbContextOptionsBuilder
        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseNpgsql(configuration.GetConnectionString("MovieReviewConnectionString"),
                prj => prj.MigrationsAssembly("MovieReviewApi"));

        return new RepositoryContext(builder.Options);
    }
}