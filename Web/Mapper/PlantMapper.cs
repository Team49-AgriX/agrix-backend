using Domain.Dto;
using Domain.Enums;
using Service.Interface;
using Web.Extensions;
using Web.Request;
using Web.Response;
using Web.Response.Plant_Response;

namespace Web.Mapper;

public class PlantMapper
{
    private readonly IPlantService _plantService;

    public PlantMapper(IPlantService plantService)
    {
        _plantService = plantService;
    }

    public async Task<PlantResponse> IdentifyAsync(IFormFile[] images, Organ[] organs, PlantIdentificationQueryRequest request)
    {
        var dto = new PlantIdentificationDto()
        {
            Project = request.Project,
            IncludeRelatedImages = request.IncludeRelatedImages,
            NoReject = request.NoReject,
            NumResult = request.NumResults,
            Language = request.Language,
            Type = request.Type,
            Detailed = request.Detailed,
            Organs = [organs.ToString()],
            Images = [images.ToString()]
        };

        var result = await _plantService.IdentifyAsync(images, organs, dto);
        return result.ToFinalResponse();
    }
}