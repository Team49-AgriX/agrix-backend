using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class FruitDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ScientificName { get; set; } = string.Empty;
        public string Family { get; set; } = string.Empty;
        public string Genus { get; set; } = string.Empty;
        public string[] CommonNames { get; set; } = [];
        public string OriginRegion { get; set; } = string.Empty;
        public string[] AgroecologicalZones { get; set; } = [];
        public string HarvestSeason { get; set; } = string.Empty;
        public string[] CulinaryUses { get; set; } = [];
        public string NutritionalInfo { get; set; } = string.Empty;
        public bool HasSeeds { get; set; }
        public string TasteProfile { get; set; } = string.Empty;
    }
}
