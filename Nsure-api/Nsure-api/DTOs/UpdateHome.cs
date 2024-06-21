namespace Nsure_api.DTOs
{
    public class UpdateHome
    {
        public int Id { get; set; }
        public string coverTier { get; set; }
        public string coverType { get; set; }
        public string postcode { get; set; }
        public string addressFull { get; set; }
        public int sumInsured { get; set; }
        public int mandatoryExcess { get; set; }
    }
}
