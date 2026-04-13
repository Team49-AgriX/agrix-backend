namespace Domain.Dto;

public class DiseaseIdDto
{
    public string Language { get; set; } 
    public string [] Images { get; set; } = [];
    public string [] Organs { get; set; } = []; 
    public bool IncludeRelatedImages { get; set; } 
    public bool NoReject { get; set; }
    public int NumResult {get; set; }
}