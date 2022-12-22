namespace V_Project.Application;

public interface IApplicationDbContext : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}