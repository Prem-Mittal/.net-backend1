﻿namespace WebApplication1.Models.DTOs
{
    public class WalksDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }
        public string? WalkImageurl { get; set; }

        //public Guid DifficultyId { get; set; }

        //public Guid RegionId { get; set; }

        public RegionDto Region { get; set; }

        public DifficultyDto Difficulty { get; set; }
    }
}
