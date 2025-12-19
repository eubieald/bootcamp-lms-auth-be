using lms_auth_be.DBContext;
using lms_auth_be.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lms_auth_be.Repositories;

public abstract class GenericRepo<T>(DatabaseContext dbContext) : IGenericRepo<T> where T : class
{
    protected readonly DatabaseContext dbContext = dbContext;
    protected readonly DbSet<T> table = dbContext.Set<T>();

    public async Task CreateAsync(T entity)
    {
        Console.WriteLine($"Repo: {dbContext.ContextId}");
        await this.table.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        this.table.Remove(entity);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await this.table.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter)
    {
        return await this.table.Where(filter).ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
       return await this.table.FindAsync(id);
    }

    public async Task<T?> GetOne(Expression<Func<T, bool>> filter)
    {
        return await this.table.Where(filter).FirstOrDefaultAsync();
    }

    public async Task SaveAsync()
    {
        await this.dbContext.SaveChangesAsync();
    }
}
