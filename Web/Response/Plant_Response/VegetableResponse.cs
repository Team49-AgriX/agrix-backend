namespace Web.Response.Plant_Response
{
    public record VegetableResponse(
        int Id,
        string Name,
        string Description,
        string ImageUrl,
        string ScientificName,
        string Family,
        string Genus,
        string[] CommonNames,
        string OriginRegion,
        string[] AgroecologicalZones,
        string HarvestSeason,
        string[] CulinaryUses,
        string NutritionalInfo,
        string EdiblePart,
        bool IsLeafy,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
