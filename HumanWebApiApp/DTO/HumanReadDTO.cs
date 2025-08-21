using System.ComponentModel.DataAnnotations;

namespace HumanWebApiApp.DTO
{
    public class HumanReadDTO
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string citizenship { get; set; }
        public string email { get; set; }
    }
}
