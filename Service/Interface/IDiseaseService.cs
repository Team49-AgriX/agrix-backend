using Domain.Dto;
using Domain.Enums;
using Domain.Models.DiseaseID;
using Microsoft.AspNetCore.Http;

namespace Service.Interface;

public interface IDiseaseService
{
    Task<string> IdentifyAsync(string userId, IFormFile[] images, Organ[]organs, DiseaseIdDto queryDto);
    Task<string> GetDiseaseInfoAsync(Disease disease, CancellationToken cancellationToken);
}