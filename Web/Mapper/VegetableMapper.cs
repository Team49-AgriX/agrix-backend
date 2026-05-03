using Domain.Dto;
using Service.Interface;
using Web.Extensions;
using Web.Request;
using Web.Response.Plant_Response;

namespace Web.Mapper
{
    public class VegetableMapper
    {
        private readonly IVegetableService _vegetableService;

        public VegetableMapper(IVegetableService vegetableService)
        {
            _vegetableService = vegetableService;
        }

        public async Task<List<VegetableResponse>> GetAllAsync()
        {
            var vegetables = await _vegetableService.GetAllAsync();
            return vegetables.Select(v => v.ToVegetableResponse()).ToList();
        }

        public async Task<VegetableResponse?> GetByIdAsync(int id)
        {
            var vegetable = await _vegetableService.GetByIdAsync(id);
            return vegetable?.ToVegetableResponse();
        }

        public async Task<VegetableResponse> CreateAsync(VegetableRequest request)
        {
            var dto = new VegetableDto
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                ScientificName = request.ScientificName,
                Family = request.Family,
                Genus = request.Genus,
                CommonNames = request.CommonNames,
                OriginRegion = request.OriginRegion,
                AgroecologicalZones = request.AgroecologicalZones,
                HarvestSeason = request.HarvestSeason,
                CulinaryUses = request.CulinaryUses,
                NutritionalInfo = request.NutritionalInfo,
                EdiblePart = request.EdiblePart,
                IsLeafy = request.IsLeafy
            };

            var vegetable = await _vegetableService.CreateAsync(dto);
            return vegetable.ToVegetableResponse();
        }

        public async Task<VegetableResponse> UpdateAsync(int id, VegetableRequest request)
        {
            var dto = new VegetableDto
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                ScientificName = request.ScientificName,
                Family = request.Family,
                Genus = request.Genus,
                CommonNames = request.CommonNames,
                OriginRegion = request.OriginRegion,
                AgroecologicalZones = request.AgroecologicalZones,
                HarvestSeason = request.HarvestSeason,
                CulinaryUses = request.CulinaryUses,
                NutritionalInfo = request.NutritionalInfo,
                EdiblePart = request.EdiblePart,
                IsLeafy = request.IsLeafy
            };

            var vegetable = await _vegetableService.UpdateAsync(id, dto);
            return vegetable.ToVegetableResponse();
        }

        public async Task<VegetableResponse> DeleteAsync(int id)
        {
            var vegetable = await _vegetableService.DeleteAsync(id);
            return vegetable.ToVegetableResponse();
        }
    }
}
