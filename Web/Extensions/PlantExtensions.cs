using Domain.Dto;
using Domain.Models.PlantID;
using Web.Response.Plant_Response;

namespace Web.Extensions;

public static class PlantExtensions
{
    public static PlantIdentificationQueryResponse ToPlantIdentificationQueryResponse (this PlantIdentificationDto dto)
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

    public static ExternalReferenceResponse ToExternalReferenceResponse(this ExternalReference externalReference)
    {
        return new ExternalReferenceResponse(
            externalReference.Id
        );
    }

    public static PlantResultResponse ToPlantResultResponse(this PlantResult plantResult)
    {
        return new PlantResultResponse(
            plantResult.Score,
            plantResult.Species.ToSpeciesResponse(),
            plantResult.Gbif?.ToExternalReferenceResponse(),
            plantResult.Powo?.ToExternalReferenceResponse()
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
}