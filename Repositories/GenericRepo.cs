using lms_auth_be.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lms_auth_be.Repositories;

public class GenericRepo<T>(DatabaseContext dbContext, DbSet<T> table) : IGenericRepo<T> where T : class
{
    private readonly DatabaseContext dbContext = dbContext;
    private readonly DbSet<T> table = table;

    public async Task Create(T entity)
    {
        await this.table.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteById(T entity)
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
