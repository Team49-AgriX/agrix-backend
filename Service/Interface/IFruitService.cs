using Domain.Dto;
using Domain.Models.Plants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IFruitService
    {
        Task<List<Fruit>> GetAllAsync();
        Task<Fruit?> GetByIdAsync(int id);
        Task<Fruit> GetByIdNotNullAsync(int id);
        Task<Fruit> CreateAsync(FruitDto dto);
        Task<Fruit> UpdateAsync(int id, FruitDto dto);
        Task<Fruit> DeleteAsync(int id);
    }
}
