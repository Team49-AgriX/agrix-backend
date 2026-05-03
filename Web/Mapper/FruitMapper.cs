using Domain.Dto;
using Service.Interface;
using Web.Extensions;
using Web.Request;
using Web.Response.Plant_Response;

namespace Web.Mapper
{
    public class FruitMapper
    {
        private readonly IFruitService _fruitService;

        public FruitMapper(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        public async Task<List<FruitResponse>> GetAllAsync()
        {
            var fruits = await _fruitService.GetAllAsync();
            return fruits.Select(f => f.ToFruitResponse()).ToList();
        }

        public async Task<FruitResponse?> GetByIdAsync(int id)
        {
            var fruit = await _fruitService.GetByIdAsync(id);
            return fruit?.ToFruitResponse();
        }

        public async Task<FruitResponse> CreateAsync(FruitRequest request)
        {
            var dto = new FruitDto
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
                HasSeeds = request.HasSeeds,
                TasteProfile = request.TasteProfile
            };

            var fruit = await _fruitService.CreateAsync(dto);
            return fruit.ToFruitResponse();
        }

        public async Task<FruitResponse> UpdateAsync(int id, FruitRequest request)
        {
            var dto = new FruitDto
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
                HasSeeds = request.HasSeeds,
                TasteProfile = request.TasteProfile
            };

            var fruit = await _fruitService.UpdateAsync(id, dto);
            return fruit.ToFruitResponse();
        }

        public async Task<FruitResponse> DeleteAsync(int id)
        {
            var fruit = await _fruitService.DeleteAsync(id);
            return fruit.ToFruitResponse();
        }
    }
}
