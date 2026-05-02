using ArtDecoMebel.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtDecoMebel.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Псевдоним")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        [MaxLength(32, ErrorMessage = "Дължината трябва да бъде до 32 символа.")]
        public string Nickname { get; set; }

        [DisplayName("Телефонен номер")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        [Phone(ErrorMessage = "Телефонният номер е невалиден.")]
        public override string PhoneNumber { get; set; }

        [DisplayName("Каталози")]
        public List<Catalog> Catalogs { get; set; } = new List<Catalog>();
    }
}
