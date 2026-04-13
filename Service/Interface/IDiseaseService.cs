using Domain.Dto;
using Domain.Enums;
using Domain.Models.DiseaseID;
using Microsoft.AspNetCore.Http;

namespace Service.Interface;

public interface IDiseaseService
{
    Task<Disease> IdentifyAsync(IFormFile[] images, Organ[]organs, DiseaseIdDto queryDto);
}