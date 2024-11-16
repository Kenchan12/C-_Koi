namespace KoiManagementSystem.Models
{
    public class Pond
    {
        public int PondId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Size { get; set; }
        public double Depth { get; set; }
        public double Volume { get; set; }
        public int DrainCount { get; set; }
        public double PumpCapacity { get; set; }
    }
}