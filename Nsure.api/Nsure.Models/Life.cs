namespace Nsure.api.Nsure.Models
{
    public class Life
    {
        public DateTime renewalDate { get; set; }
        public DateTime inceptionDate { get; set; }
        public string coverTier { get; set; }
        public string nameInsured { get; set; }
        public string coverType { get; set; }
        public int benefitAmount { get; set; }
        public int benefitPeriod { get; set; }  
        public string basisOfAdvice { get; set; }
    }
}
