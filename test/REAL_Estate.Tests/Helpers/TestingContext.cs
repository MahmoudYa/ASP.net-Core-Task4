using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using REAL_Estate.Data;
using REAL_Estate.Objects;
using REAL_Estate.Objects.Mapping;

namespace REAL_Estate;

public static class TestingContext
{
    public static IMapper Mapper { get; }
    private static DbContextOptions Options { get; }

    static TestingContext()
    {
        IConfiguration config = new ConfigurationBuilder().AddJsonFile($"configuration.testing.json").AddEnvironmentVariables("REAL_Estate__Testing__").Build();
        Mapper = new MapperConfiguration(mapper => mapper.AddProfile(new MappingProfile())).CreateMapper();
        Options = new DbContextOptionsBuilder().UseSqlServer(config["Data:Connection"]).Options;

        using Context context = new(Options);

        context.Database.Migrate();
    }

    public static DbContext Create()
    {
        return new Context(Options);
    }

    public static DbContext Drop(this DbContext context)
    {
        context.RemoveRange(context.Set<RolePermission>());
        context.RemoveRange(context.Set<Permission>());
        context.RemoveRange(context.Set<AuditLog>());
        context.RemoveRange(context.Set<Account>());
        context.RemoveRange(context.Set<Role>());

        context.SaveChanges();

        return context;
    }
    public static IQueryable<T> Db<T>(this DbContext context) where T : class
    {
        return context.Set<T>().AsNoTracking();
    }
}
