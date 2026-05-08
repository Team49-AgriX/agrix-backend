using Domain.Dto;
using Domain.Models.Plants;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Implementation
{
    public class VegetableService : IVegetableService
    {
        private readonly IRepository<Vegetable> _repository;

        public VegetableService(IRepository<Vegetable> repository)
        {
            _repository = repository;
        }
        public Task<List<Vegetable>> GetAllAsync()
        {
            return _repository.GetAllAsync(v => v, asNoTracking: true);
        }

        public Task<Vegetable?> GetByIdAsync(int id)
        {
            return _repository.GetAsync(v => v, v => v.Id == id, asNoTracking: true);
        }

        public async Task<Vegetable> GetByIdNotNullAsync(int id)
        {
            var result = await _repository.GetAsync(f => f, f => f.Id == id);
            if (result == null)
                throw new KeyNotFoundException($"Vegetable with id {id} not found.");
            return result;
        }

        public async Task<Vegetable> CreateAsync(VegetableDto dto)
        {
            var exists = await _repository.ExistsAsync(f => f.Name.ToLower() == dto.Name.ToLower());
            if (exists)
                throw new InvalidOperationException($"Vegetable '{dto.Name}' already exists.");
            var entity = MapToEntity(dto);
            return await _repository.InsertAsync(entity);
        }

        public async Task<Vegetable> UpdateAsync(int id, VegetableDto dto)
        {
            var existing = await GetByIdNotNullAsync(id);
            MapDtoToExisting(dto, existing);
            existing.UpdatedAt = DateTime.UtcNow;
            return await _repository.UpdateAsync(existing);
        }

        public async Task<Vegetable> DeleteAsync(int id)
        {
            var existing = await GetByIdNotNullAsync(id);
            return await _repository.DeleteAsync(existing);
        }

        private static Vegetable MapToEntity(VegetableDto dto) => new()
        {
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            ScientificName = dto.ScientificName,
            Family = dto.Family,
            Genus = dto.Genus,
            CommonNames = dto.CommonNames,
            OriginRegion = dto.OriginRegion,
            AgroecologicalZones = dto.AgroecologicalZones,
            HarvestSeason = dto.HarvestSeason,
            CulinaryUses = dto.CulinaryUses,
            NutritionalInfo = dto.NutritionalInfo,
            EdiblePart = dto.EdiblePart,
            IsLeafy = dto.IsLeafy
        };

        private static void MapDtoToExisting(VegetableDto dto, Vegetable entity)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.ImageUrl = dto.ImageUrl;
            entity.ScientificName = dto.ScientificName;
            entity.Family = dto.Family;
            entity.Genus = dto.Genus;
            entity.CommonNames = dto.CommonNames;
            entity.OriginRegion = dto.OriginRegion;
            entity.AgroecologicalZones = dto.AgroecologicalZones;
            entity.HarvestSeason = dto.HarvestSeason;
            entity.CulinaryUses = dto.CulinaryUses;
            entity.NutritionalInfo = dto.NutritionalInfo;
            entity.EdiblePart = dto.EdiblePart;
            entity.IsLeafy = dto.IsLeafy;
        }
    }
}
