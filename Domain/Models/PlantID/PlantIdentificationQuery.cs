using Domain.Common;

namespace Domain.Models.PlantID;

public class PlantIdentificationQuery : BaseEntity
{
    public string Project { get; set; } = "all";
    public string Language { get; set; } = "en";
    public string Type { get; set; } = "kt";
    public string [] Images { get; set; } = [];
    public string [] Organs { get; set; } = []; 
    public bool IncludeRelatedImages { get; set; } = false;
    public bool NoReject { get; set; } = false;
    public bool Detailed { get; set; } = false;
    
    public int NumResult {get; set;} = 1;
}