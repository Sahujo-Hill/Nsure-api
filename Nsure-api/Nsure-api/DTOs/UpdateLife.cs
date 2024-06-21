namespace Nsure_api.DTOs
{
    public class UpdateLife
    {
        public int Id { get; set; }
        public string coverTier { get; set; }
        public string nameInsured { get; set; }
        public string coverType { get; set; }
        public int benefitAmount { get; set; }
        public int benefitPeriod { get; set; }
        public string basisOfAdvice { get; set; }
    }
}
