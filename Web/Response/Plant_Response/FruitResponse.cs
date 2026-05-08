namespace Web.Response.Plant_Response
{
    public record FruitResponse(
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
        bool HasSeeds,
        string TasteProfile,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
