using Domain.Dto;
using Domain.Models.Plants;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Implementation
{
    public class FruitService : IFruitService
    {
        private readonly IRepository<Fruit> _repository;

        public FruitService(IRepository<Fruit> repository)
        {
            _repository = repository;
        }

        public Task<List<Fruit>> GetAllAsync()
        {
            return _repository.GetAllAsync(f => f, asNoTracking: true);
        }

        public Task<Fruit?> GetByIdAsync(int id)
        {
            return _repository.GetAsync(f => f, f => f.Id == id, asNoTracking: true);
        }

        public async Task<Fruit> GetByIdNotNullAsync(int id)
        {
            var result = await _repository.GetAsync(f => f, f => f.Id == id);
            if (result == null)
                throw new KeyNotFoundException($"Fruit with id {id} not found.");
            return result;
        }

        public async Task<Fruit> CreateAsync(FruitDto dto)
        {
            var exists = await _repository.ExistsAsync(f => f.Name.ToLower() == dto.Name.ToLower());
            if (exists)
                throw new InvalidOperationException($"Fruit '{dto.Name}' already exists.");

            var entity = MapToEntity(dto);
            return await _repository.InsertAsync(entity);
        }

        public async Task<Fruit> UpdateAsync(int id, FruitDto dto)
        {
            var existing = await GetByIdNotNullAsync(id);
            MapDtoToExisting(dto, existing);
            existing.UpdatedAt = DateTime.UtcNow;
            return await _repository.UpdateAsync(existing);
        }

        public async Task<Fruit> DeleteAsync(int id)
        {
            var existing = await GetByIdNotNullAsync(id);
            return await _repository.DeleteAsync(existing);
        }

        private static Fruit MapToEntity(FruitDto dto) => new()
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
            HasSeeds = dto.HasSeeds,
            TasteProfile = dto.TasteProfile
        };

        private static void MapDtoToExisting(FruitDto dto, Fruit entity)
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
            entity.HasSeeds = dto.HasSeeds;
            entity.TasteProfile = dto.TasteProfile;
        }
    }
}
