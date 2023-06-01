using Core.Domain;

namespace Core.Application.Interfaces;

public interface ISrnpPriceRepository: IGenericRepository<SrnpPrice>
{
    Task<List<string[]>> GetNumbers(bool isSameLetter);
    Task<string> GetPriceInMci();
    Task<SrnpPrice> GetSrnpPrice(string[] t);
    Task<SrnpPrice?> GetSrnpPriceIfNull(bool isSameLetter);
}