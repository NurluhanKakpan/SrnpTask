using Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _dataContext;

    public GenericRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public   IEnumerable<T> GetAll()
    {
        return  _dataContext.Set<T>().ToList();
    }
    
}