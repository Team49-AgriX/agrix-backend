namespace Domain.Dto;

public class PlantIdentificationDto
{
    public string Project { get; set; }
    public string Language { get; set; } 
    public string Type { get; set; } 
    
    public string [] Images { get; set; } = [];
    public string [] Organs { get; set; } = []; 
    public bool IncludeRelatedImages { get; set; } 
    public bool NoReject { get; set; }
    public bool Detailed { get; set; } 
    public int NumResult {get; set; } 
}