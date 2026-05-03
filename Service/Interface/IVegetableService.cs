using Domain.Dto;
using Domain.Models.Plants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IVegetableService
    {
        Task<List<Vegetable>> GetAllAsync();
        Task<Vegetable?> GetByIdAsync(int id);
        Task<Vegetable> GetByIdNotNullAsync(int id);
        Task<Vegetable> CreateAsync(VegetableDto dto);
        Task<Vegetable> UpdateAsync(int id, VegetableDto dto);
        Task<Vegetable> DeleteAsync(int id);
    }
}
