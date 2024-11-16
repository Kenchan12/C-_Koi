﻿namespace KoiManagementSystem.Models
{
    public class KoiFish
    {
        public int KoiId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string BodyShape { get; set; }
        public int Age { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public string Origin { get; set; }
        public decimal Price { get; set; }
        public int PondId { get; set; }
        public Pond Pond { get; set; }
    }
}