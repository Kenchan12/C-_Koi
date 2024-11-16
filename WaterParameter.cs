namespace KoiManagementSystem.Models
{
    public class WaterParameter
    {
        public int ParameterId { get; set; }
        public int PondId { get; set; }
        public DateTime MeasurementDate { get; set; }
        public double Temperature { get; set; }
        public double Salinity { get; set; }
        public double PH { get; set; }
        public double O2 { get; set; }
        public double NO2 { get; set; }
        public double NO3 { get; set; }
        public double PO4 { get; set; }
        public Pond Pond { get; set; } = new Pond();
    }
}