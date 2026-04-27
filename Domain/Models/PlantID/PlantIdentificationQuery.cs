using Domain.Common;

namespace Domain.Models.PlantID;

public class PlantIdentificationQuery : BaseEntity
{
    public string Project { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string [] Images { get; set; } = [];
    public string [] Organs { get; set; } = []; 
    public bool IncludeRelatedImages { get; set; } 
    public bool NoReject { get; set; } 
    public bool Detailed { get; set; } 
    
    public int NumResult {get; set;} 
}