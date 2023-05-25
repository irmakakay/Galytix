using AutoMapper;
using Galytix.Api.DataAccess;
using Galytix.Api.Model.Entities;
using Galytix.Api.Model.Web;

namespace Galytix.Api.Services;

public class GwpDataService : IGwpDataService
{
    private readonly IGwpDataRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GwpDataService> _logger;
    
    public GwpDataService(IGwpDataRepository repository, IMapper mapper, ILogger<GwpDataService> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<Dictionary<string, double>> GetAverageGwpByCountryAndLinesOfBusiness(GetAverageGwpRequest request)
    {
        try
        {
            if (request == null || 
                string.IsNullOrWhiteSpace(request.Country) ||
                request.LinesOfBusiness.Any(lob => string.IsNullOrWhiteSpace(lob)))
            {
                throw new ArgumentException(nameof(request));
            }

            var query = _mapper.Map<GetAverageGwpRequest, AverageGwpQuery>(request);
            var result = await _repository.GetAverages(query);

            foreach (var key in result.Keys.Where(key => !query.LinesOfBusiness.Contains(key)))
            {
                result.Remove(key);
            }

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Gwp averages.");
            throw;
        }
    }
}