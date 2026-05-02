using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtDecoMebel.Models
{
    public class Catalog
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Потребител")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? ApplicationUser { get; set; }

        [DisplayName("Име на каталог")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "Името трябва да е между 1 и 32 символа.")]
        public string? Name { get; set; }

        [DisplayName("Мебели")]
        public List<Furniture> Furnitures { get; set; } = new List<Furniture>();
    }
}
