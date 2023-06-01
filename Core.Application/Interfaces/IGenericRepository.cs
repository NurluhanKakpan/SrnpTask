namespace Core.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll();
}