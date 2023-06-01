using Core.Application.DTOs;
using Core.Domain;

namespace Core.Application.Services;

public interface ISrnpResultService
{
    Task<List<SrnpResultDto>> GetResult(List<string> srnps);
}