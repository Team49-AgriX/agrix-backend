using Domain.Dto;
using Domain.Enums;
using Service.Interface;
using Web.Extensions;
using Web.Request;
using Web.Response.Disease_Response;

namespace Web.Mapper;

public class DiseaseMapper
{
    private readonly IDiseaseService _diseaseService;

    public DiseaseMapper(IDiseaseService diseaseService)
    {
        _diseaseService = diseaseService;
    }
    
    public async Task<string> IdentifyAsync(IFormFile[] images, Organ[] organs, DiseaseIDqueryRequest request)
    {
        var dto = new DiseaseIdDto()
        {
            IncludeRelatedImages = request.IncludeRelatedImages,
            NoReject = request.NoReject,
            NumResult = request.NumResults,
            Language = request.Language,
            Organs = [organs.ToString()],
            Images = [images.ToString()]
        };

        // var result = await _diseaseService.IdentifyAsync(images, organs, dto);
        // return result.ToDiseaseResponse();
        
        return await _diseaseService.IdentifyAsync(images, organs, dto);
    }
}