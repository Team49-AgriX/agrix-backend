using Domain.Dto;
using Domain.Enums;
using Domain.Models.PlantID;
using Microsoft.AspNetCore.Http;

namespace Service.Interface;

public interface IPlantService
{
    Task<Plant> IdentifyAsync(IFormFile[] images, Organ[]organs, PlantIdentificationDto queryDto);
}