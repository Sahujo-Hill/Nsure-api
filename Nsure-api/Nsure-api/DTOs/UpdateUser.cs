namespace Nsure_api.DTOs
{
    public class UpdateUser
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool carPolicy { get; set; }
        public bool homePolicy { get; set; }
        public bool lifePolicy { get; set; }

    }
}
