using Core.Application.Interfaces;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Repositories;

public class SrnpPriceRepository : GenericRepository<SrnpPrice>,ISrnpPriceRepository
{
    private readonly DataContext _dataContext;
    public SrnpPriceRepository(DataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<string[]>> GetNumbers(bool isSameLetter)
    {
        var result = await _dataContext.SrnpPrices.Where(q =>q.IsSameLetter == isSameLetter).Select(e =>e.Numbers)
            .ToListAsync();
        return result!;
    }

    public async Task<string> GetPriceInMci()
    {
        var result = await _dataContext.SrnpPrices.FirstOrDefaultAsync(e =>e.PriceCategory == 0);
        return result!.PriceInMci!;
    }

    public async Task<SrnpPrice> GetSrnpPrice(string[] t)
    {
        var result = await _dataContext.SrnpPrices.FirstOrDefaultAsync(e =>e.Numbers == t);
        return result!;
    }

    public async Task<SrnpPrice?> GetSrnpPriceIfNull(bool isSameLetter)
    {
        var result=  await _dataContext.SrnpPrices.FirstOrDefaultAsync(e =>e.IsSameLetter == isSameLetter && e.Numbers == null);
        return result;
    }
}