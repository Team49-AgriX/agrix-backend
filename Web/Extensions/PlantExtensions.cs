using Domain.Models.PlantID;
using Domain.Models.Plants;
using Web.Response.Plant_Response;

namespace Web.Extensions;

public static class PlantExtensions
{
    public static PlantIdentificationQueryResponse ToPlantIdentificationQueryResponse (this PlantIdentificationQuery dto)
    {
        return new PlantIdentificationQueryResponse(
            dto.Project,
            dto.Images,
            dto.Organs,
            dto.IncludeRelatedImages,
            dto.NoReject,
            dto.Type);
    }

    public static PredictedOrganResponse ToPredictedOrganResponse(this PredictedOrgan organ)
    {
        return new PredictedOrganResponse(
            organ.Image,
            organ.FileName,
            organ.Organ,
            organ.Score
            );
    }

    public static TaxonResponse ToTaxonResponse(this Taxon taxon)
    {
        return new TaxonResponse(
            taxon.ScientificNameWithoutAuthor,
            taxon.ScientificNameAuthorship,
            taxon.ScientificName
        );
    }

    public static SpeciesResponse ToSpeciesResponse(this Species species)
    {
        return new SpeciesResponse(
            species.ScientificNameWithoutAuthor,
            species.ScientificNameAuthorship,
            species.Genus.ToTaxonResponse(),
            species.Family.ToTaxonResponse(),
            species.CommonNames,
            species.ScientificName
        );
    }
    
    public static PlantResultResponse ToPlantResultResponse(this PlantResult plantResult)
    {
        return new PlantResultResponse(
            plantResult.Score,
            plantResult.Species.ToSpeciesResponse()
            );
    }

    public static PlantResponse ToFinalResponse(this Plant plant)
    {
        return new PlantResponse(
            plant.Query.ToPlantIdentificationQueryResponse(),
            plant.PredictedOrgans.Select(x => x.ToPredictedOrganResponse()).ToArray(),
            plant.Language,
            plant.PreferedReferential,
            plant.BestMatch,
            plant.Results.Select(x => x.ToPlantResultResponse()).ToArray()
        );
    }

    public static FruitResponse ToFruitResponse(this Fruit fruit) {
        return new FruitResponse (
            fruit.Id,
            fruit.Name,
            fruit.Description,
            fruit.ImageUrl,
            fruit.ScientificName,
            fruit.Family,
            fruit.Genus,
            fruit.CommonNames,
            fruit.OriginRegion,
            fruit.AgroecologicalZones,
            fruit.HarvestSeason,
            fruit.CulinaryUses,
            fruit.NutritionalInfo,
            fruit.HasSeeds,
            fruit.TasteProfile,
            fruit.CreatedAt,
            fruit.UpdatedAt
        );
    }

    public static VegetableResponse ToVegetableResponse(this Vegetable vegetable) {
        return new VegetableResponse (
            vegetable.Id,
            vegetable.Name,
            vegetable.Description,
            vegetable.ImageUrl,
            vegetable.ScientificName,
            vegetable.Family,
            vegetable.Genus,
            vegetable.CommonNames,
            vegetable.OriginRegion,
            vegetable.AgroecologicalZones,
            vegetable.HarvestSeason,
            vegetable.CulinaryUses,
            vegetable.NutritionalInfo,
            vegetable.EdiblePart,
            vegetable.IsLeafy,
            vegetable.CreatedAt,
            vegetable.UpdatedAt
        );
    }
}