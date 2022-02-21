using System.ComponentModel.DataAnnotations;

namespace WebApplicationTest.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
