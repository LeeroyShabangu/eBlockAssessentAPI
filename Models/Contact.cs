using System.ComponentModel.DataAnnotations;

namespace eBlockAssessent.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string ContactInfo { get; set; }
    }
}
