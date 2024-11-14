using EduFlex.Data.DbContexts;
using EduFlex.Data.IRepositories;
using EduFlex.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace EduFlex.Data.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext dbContext;
    private readonly DbSet<TEntity> dbSet;

    public RepositoryBase(AppDbContext dbContext,DbSet<TEntity> dbSet)
    {
        this.dbContext = dbContext;
        this.dbSet = dbSet;
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await this.dbSet.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();

        return entity;
    }

    public IQueryable<TEntity> GetAllAsync()
        => this.dbSet;

    public async Task<TEntity> GetByIdAsync(long id)
    {
        var result = await this.dbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
        return result;
    }

           
    public async Task<bool> RemoveAsync(long id)
    {
        await this.dbSet.Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var result = dbContext.Update(entity).Entity;
        await dbContext.SaveChangesAsync();
        return result;
    }
}
