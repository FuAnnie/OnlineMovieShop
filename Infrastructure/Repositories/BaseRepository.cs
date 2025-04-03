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
        movieDbContext.Set<T>().Add(entity);
        return await movieDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        movieDbContext.Set<T>().Update(entity);
        return await movieDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var item = GetByIdAsync(id).Result;
        movieDbContext.Set<T>().Remove(item);
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