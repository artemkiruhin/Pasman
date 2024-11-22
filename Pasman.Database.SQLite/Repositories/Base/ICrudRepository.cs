namespace Pasman.Database.SQLite.Repositories.Base;

public interface ICrudRepository<TEntity>
{
    Task<bool> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
}