namespace Nsure.api.Nsure.Models
{
    public class Car
    {
        public DateTime renewalDate { get; set; }
        public DateTime inceptionDate { get; set; }
        public string coverTier { get; set; }
        public string reg { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int ncbYears { get; set; }
        public string addressStored { get; set; }
    }
}
