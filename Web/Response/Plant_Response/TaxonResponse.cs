namespace Web.Response.Plant_Response;

public record TaxonResponse(
    string ScientificNameWithoutAuthor,
    string ScientificNameAuthorship,
    string ScientificName
    );