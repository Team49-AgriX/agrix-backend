using Domain.Dto;
using Domain.Enums;
using Domain.Models.PlantID;
using Microsoft.AspNetCore.Http;

namespace Service.Interface;

public interface IPlantService
{
    Task<string> IdentifyAsync(string userId, IFormFile[] images, Organ[]organs, PlantIdentificationDto queryDto);
    Task<string> GetPlantInfoAsync(Plant plant, CancellationToken cancellationToken);
}