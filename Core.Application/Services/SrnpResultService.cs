using System.Text.RegularExpressions;
using Core.Application.DTOs;
using Core.Application.Interfaces;
using Core.Domain;

namespace Core.Application.Services;

public class SrnpResultService : ISrnpResultService
{

    private readonly ISrnpInfoRepository _srnpInfoRepository;
    private readonly ISrnpPriceRepository _srnpPriceRepository;

    public SrnpResultService(ISrnpInfoRepository srnpInfoRepository, ISrnpPriceRepository srnpPriceRepository)
    {
        _srnpInfoRepository = srnpInfoRepository;
        _srnpPriceRepository = srnpPriceRepository;
    }
    public async Task<List<SrnpResultDto>> GetResult(List<string> srnps)
    {
        var listResult = new List<SrnpResultDto>();
        var patterns = await GetPattern(srnps);
        for (var i = 0; i < patterns.Count; i++)
        {
            if (patterns[i] == "Not Found")
            {
                listResult.Add(new SrnpResultDto{Srnp = srnps[i]});
            }
            else
            {
                var listOfSrnpResultDto =  await GetListOfSrnpResultDto(patterns, srnps, i);
                for (int j = 0; j < listOfSrnpResultDto.Count; j++)
                {
                        listResult.Add(listOfSrnpResultDto[j]);
                }
            }
        }
        return listResult;
    }
    private  async Task<List<SrnpResultDto>> GetListOfSrnpResultDto(List<string> patterns, List<string> srnps, int i)
    {
        var listOfResultSrnpResultDto = new List<SrnpResultDto>();
        var typesOfSrnp = await _srnpInfoRepository.GetTypeByRegex(patterns[i]);
        for (var j = 0; j < typesOfSrnp.Count; j++)
        {
            for (var k = 0; k < typesOfSrnp[j].Length; k++)
            {
                var srnpInfo = await _srnpInfoRepository.GetSrnpInfo(typesOfSrnp[j],patterns[i]);
                var srnp = new SrnpResultDto
                    {
                        Srnp = srnps[i],
                        SrnpType = typesOfSrnp[j][k],
                        SrnpNumber = GetWord(srnpInfo.Number, patterns[i], srnps[i]),
                        SrnpSeries = GetWord(srnpInfo.Series, patterns[i], srnps[i]),
                        SrnpRegion = GetWord(srnpInfo.Region, patterns[i], srnps[i]),
                        SrnpGovCode = GetWord(srnpInfo.GovCode, patterns[i], srnps[i]),
                        SrnpColor = srnpInfo.Color,
                        TypePerson = srnpInfo.TypePerson,
                        TechCategory = srnpInfo.TechCategory,
                        SrnpCode = srnpInfo.SrnpTypeCode![typesOfSrnp[j][k]],
                        IsForbiddenSeries = false,
                        SrnpCount = srnpInfo.SrnpCount 
                    };
                if ( await IsForbiddenSeries(srnp.SrnpSeries))
                {
                    listOfResultSrnpResultDto.Add(new SrnpResultDto
                    {
                        Srnp = srnps[i],
                        IsForbiddenSeries = true
                    });
                    break;
                }
                if (srnp.SrnpNumber == "000" || srnp.SrnpNumber == "00" || srnp.SrnpNumber == "0000" && await IsForbiddenSeries(srnp.SrnpSeries) == false)
                {
                    listOfResultSrnpResultDto.Add(new SrnpResultDto{Srnp = srnps[i]});
                    break;
                }
                if (typesOfSrnp[j] is ["1","2"] or ["1А","2А"])
                {
                    var isSameLetter = AreAllLettersSame(srnp.SrnpSeries);
                    var srnpPrice = await GetSrnpPrice(srnp, isSameLetter);
                    srnp.SrnpPriceCategory = srnpPrice.PriceCategory;
                    srnp.SrnpPriceInMci = srnpPrice.PriceInMci;
                }
                else
                {
                    var priceInMci = await _srnpPriceRepository.GetPriceInMci();
                    srnp.SrnpPriceInMci = priceInMci;
                    srnp.SrnpPriceCategory = 0;
                }
                listOfResultSrnpResultDto.Add(srnp);
            }
        }
        return listOfResultSrnpResultDto;
    }
    private string GetWord(int place,string pattern,string srnp)
    {
        string word = null!;
        if (place <= 0) return word;
        var match = Regex.Match(srnp, pattern);
        word = match.Groups[place].Value;
        return word;
    }
    private async Task<List<string>> GetPattern(List<string> srnps)
    {
        var patterns = new List<string>();
        var patternsFromDb = await _srnpInfoRepository.GetPatternsFromDb();
        foreach (var t in srnps)
        {
            var foundRegex = "Not Found";
            foreach (var t1 in patternsFromDb.Where(t1 => Regex.IsMatch(t, t1)))
            {
                foundRegex = t1;
                break;
            }
            patterns.Add(foundRegex);
        }
        return patterns;        
        
    }
    private static bool AreAllLettersSame(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return false; 
        }
        var firstLetter = word[0];

        for (var i = 1; i < word.Length; i++)
        {
            if (word[i] != firstLetter)
            {
                return false;
            }
        }
        return true;
    }

    private async Task<SrnpPrice> GetSrnpPrice(SrnpResultDto srnpResultDto, bool isSameLetter)
    {
        var numbers = await  _srnpPriceRepository.GetNumbers(isSameLetter);
        numbers.Remove(null!);
        SrnpPrice? srnpPrice = null;
        foreach (var t in numbers)
        {
            for (var j = 0; j < t.Length; j++)
            {
                if (srnpResultDto.SrnpNumber == t[j])
                {
                    srnpPrice = await _srnpPriceRepository.GetSrnpPrice(t);
                }
            }
        }
        srnpPrice ??= await _srnpPriceRepository.GetSrnpPriceIfNull(isSameLetter);
        return srnpPrice!;
    }

    private async Task<bool> IsForbiddenSeries(string series)
    {
        var forbiddenSeries = await _srnpInfoRepository.GetForbiddenSeries();
        for (var i = 0; i < forbiddenSeries.Length; i++)
        {
            if (forbiddenSeries[i] == series)
            {
                return true;
            }
        }
        return false;
    }

}