using ResolutionFundSite.Domain.Entities;

namespace ResolutionFundSite.Application.Iinterfaces;
public interface IRepositoryBase<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}