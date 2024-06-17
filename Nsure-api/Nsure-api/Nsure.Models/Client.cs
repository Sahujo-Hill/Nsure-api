using System.Security.Cryptography;

namespace Nsure.api.Nsure.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool carPolicy { get; set; }
        public bool homePolicy { get; set; }
        public bool lifePolicy { get; set; }
    }
}
