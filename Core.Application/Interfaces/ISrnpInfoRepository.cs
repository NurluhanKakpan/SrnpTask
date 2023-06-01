using Core.Domain;

namespace Core.Application.Interfaces;

public interface ISrnpInfoRepository : IGenericRepository<SrnpInfo>
{
    Task<List<string[]>> GetTypeByRegex(string regex);
    Task<SrnpInfo> GetSrnpInfo(string[] type,string pattern);
    Task<List<string>> GetPatternsFromDb();
    Task<string[]> GetForbiddenSeries();

}