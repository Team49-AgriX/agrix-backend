using Domain.Enums;

namespace Web.Request;

public record PlantIdentificationQueryRequest(
    string Project = "all",
    bool IncludeRelatedImages = false,
    bool NoReject = false,
    int NumResults = 1, 
    string Language = "en",
    string Type = "kt",
    bool Detailed = false
    );