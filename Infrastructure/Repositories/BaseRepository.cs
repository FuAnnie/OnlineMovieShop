using ApplicationCore.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class BaseRepository<T>: IRepository<T> where T : class
{
    private readonly MovieDbContext movieDbContext;
    
    public BaseRepository(MovieDbContext movieDbContext)
    {
        this.movieDbContext = movieDbContext;
    }
    public int Insert(T entity)
    {
        movieDbContext.Set<T>().Add(entity);
        return movieDbContext.SaveChanges();
    }

    public int Update(T entity)
    {
        movieDbContext.Set<T>().Update(entity);
        return movieDbContext.SaveChanges();
    }

    public int Delete(int id)
    {
        var item = GetById(id);
        movieDbContext.Set<T>().Remove(item);
        return movieDbContext.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        return movieDbContext.Set<T>();
    }

    public T GetById(int id)
    {
        return movieDbContext.Set<T>().Find(id);
    }
}