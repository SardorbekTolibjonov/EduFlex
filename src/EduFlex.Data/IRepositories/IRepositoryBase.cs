namespace EduFlex.Data.IRepositories;

public interface IRepositoryBase<TEntity>
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> RemoveAsync(long id);
    Task<TEntity> GetByIdAsync(long id);
    IQueryable<TEntity> GetAllAsync();

}
