namespace Nsure_api.DTOs
{
    public class UpdateCar
    {
        public int Id { get; set; }
        public string coverTier { get; set; }
        public string reg { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int ncbYears { get; set; }
        public string addressStored { get; set; }
    }
}
