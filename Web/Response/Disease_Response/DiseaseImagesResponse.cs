namespace Web.Response.Disease_Response;

public record DiseaseImagesResponse(
    string Organ,
    string Author,
    string License,
    DateTime Date,
    string Citation,
    string[] Url
    );