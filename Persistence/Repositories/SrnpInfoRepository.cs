using Core.Application.Interfaces;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Repositories;

public class SrnpInfoRepository : GenericRepository<SrnpInfo>, ISrnpInfoRepository
{
    private readonly DataContext _dataContext;
    public SrnpInfoRepository(DataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<List<string[]>> GetTypeByRegex(string regex)
    {
         var result = await _dataContext.SrnpInfos.Where(q => q.Regex == regex).Select(e=>e.GrnzType).ToListAsync();
         return result!;
    }

    public async Task<SrnpInfo> GetSrnpInfo( string[] type ,string pattern)
    {
        var result = await _dataContext.SrnpInfos.FirstOrDefaultAsync(q => q.Regex == pattern && q.GrnzType == type)!;
        return result!;
    }

    public async Task<List<string>> GetPatternsFromDb()
    {
        var result = await _dataContext.SrnpInfos.Select(e => e.Regex).ToListAsync();
        return result!;
    }

    public async Task<string[]> GetForbiddenSeries()
    {
        var result = await _dataContext.ForbiddenSeries.FirstOrDefaultAsync(q=>q.Id == 1);
        return result!.ForbiddenSeriesOfNumbers!;
    }
}


