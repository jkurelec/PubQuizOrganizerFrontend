﻿namespace PubQuizOrganizerFrontend.Models.Dto.LocationDto
{
    public class LocationBriefDto
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? ProfileImage { get; set; }
    }
}
