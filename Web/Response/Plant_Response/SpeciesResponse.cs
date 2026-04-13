namespace Web.Response.Plant_Response;

public record SpeciesResponse(
    string ScientificNameWithoutAuthor,
    string ScientificNameAuthorship,
    TaxonResponse Genus,
    TaxonResponse Family,
    string[] CommonNames,
    string ScientificName
    );