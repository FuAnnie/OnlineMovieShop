using ApplicationCore.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T>: IRepository<T> where T : class
{
    protected readonly MovieDbContext movieDbContext;
    
    public BaseRepository(MovieDbContext movieDbContext)
    {
        this.movieDbContext = movieDbContext;
    }
    
    public async Task<int> InsertAsync(T entity)
    {
        await movieDbContext.Set<T>().AddAsync(entity);
        return await movieDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        movieDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await movieDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);
        if (item != null)
        {
            movieDbContext.Set<T>().Remove(item);
        }
        return await movieDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await movieDbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await movieDbContext.Set<T>().FindAsync(id);
    }
}