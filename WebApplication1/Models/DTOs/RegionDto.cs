﻿namespace WebApplication1.Models.DTOs
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }
        public string? RegionImageURL { get; set; }
    }
}