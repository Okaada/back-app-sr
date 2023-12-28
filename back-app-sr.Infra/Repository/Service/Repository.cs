using back_app_sr.Infra.Context;
using back_app_sr.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace back_app_sr.Infra.Repository.Service;

public class Repository<T>  : IRepository<T> where T : class
{
    protected readonly ApplicationContext ApplicationContext;

    public Repository(ApplicationContext context)
    {
        ApplicationContext = context;
    }
    
    public async Task<T?> GetById(int id)
    {
        return await ApplicationContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await ApplicationContext.Set<T>().ToListAsync();
    }

    public async Task Add(T entity)
{
        await ApplicationContext.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        ApplicationContext.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        ApplicationContext.Set<T>().Update(entity);
    }
}