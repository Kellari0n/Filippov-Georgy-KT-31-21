namespace Filippov_Georgy_KT_31_21.Services.Shared.Interfaces;

public interface ICrudService<TEntity> {
    public Task<TEntity> GetAsync(int id, CancellationToken cancellationToken);
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}