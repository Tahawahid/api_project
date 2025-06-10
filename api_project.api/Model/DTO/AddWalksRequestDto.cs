﻿namespace api_project.api.Model.DTO
{
    public class AddWalksRequestDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKM { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }


    }
}
