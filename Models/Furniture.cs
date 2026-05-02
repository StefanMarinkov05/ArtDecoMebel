using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtDecoMebel.Models
{
    public class Furniture
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Снимка")]
        public string? Photo { get; set; }

        [NotMapped]
        [DisplayName("Качване на снимка")]
        public IFormFile? ImageFile { get; set; }

        [DisplayName("Име")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Името трябва да е между 1 и 100 символа.")]
        public string Name { get; set; }

        [DisplayName("Марка")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand? Brand { get; set; }

        [DisplayName("Помещение")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        public int RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public Room? Room { get; set; }

        [DisplayName("Тип")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public FType? FType { get; set; }

        [DisplayName("Цветове")]
        public List<Color> Colors { get; set; } = new List<Color>();

        [DisplayName("Материали")]
        public List<Material> Materials { get; set; } = new List<Material>();

        [DisplayName("Дължина")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        [Range(0, 1000, ErrorMessage = "Стойността трябва да бъде между 0 и 1000.")]
        public double Length { get; set; }

        [DisplayName("Ширина")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        [Range(0, 1000, ErrorMessage = "Стойността трябва да бъде между 0 и 1000.")]
        public double Width { get; set; }

        [DisplayName("Височина")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        [Range(0, 1000, ErrorMessage = "Стойността трябва да бъде между 0 и 1000.")]
        public double Height { get; set; }

        [DisplayName("Година на производство")]
        [Required(ErrorMessage = "Полето не може да бъде празно.")]
        [Range(1600, int.MaxValue, ErrorMessage = "Годината е невалидна.")]
        [ProductionYearValidation]
        public int ProductionYear { get; set; }

        public List<Catalog> Catalogs { get; set; } = new List<Catalog>();
    }

    public class ProductionYearValidation : ValidationAttribute
    {
        public ProductionYearValidation()
        {
            ErrorMessage = "Годината не може да бъде в бъдещето.";
        }

        public override bool IsValid(object? value)
        {
            if (value is int year)
                return year <= DateTime.Now.Year;

            return false;
        }
    }
}
