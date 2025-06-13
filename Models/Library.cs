using System.ComponentModel.DataAnnotations;

namespace Activity_2.Models
{
    public class Library
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
    }
}
