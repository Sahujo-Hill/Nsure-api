namespace Nsure.api.Nsure.Models
{
    public class Home
    {
        public DateTime renewalDate { get; set; }
        public DateTime inceptionDate { get; set; }
        public string coverTier { get; set; }
        public string coverType { get; set; }
        public string postcode { get; set; }
        public string addressFull { get; set; }
        public int sumInsured { get; set; }
        public int mandatoryExcess { get; set; }

    }
}
