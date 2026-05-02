using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtDecoMebel.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Помещение")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Името трябва да е между 1 и 100 символа.")]
        public string Name { get; set; }
    }
}
