using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ArtDecoMebel.Models;
using System.Text.Json;
using Humanizer;

namespace ArtDecoMebel
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<FType> FTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cannot delete a Color if it's used by any Furniture
            modelBuilder.Entity("ColorFurniture", b =>
            {
                b.HasOne(typeof(Furniture), null)
                 .WithMany()
                 .HasForeignKey("FurnituresId")
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(typeof(Color), null)
                 .WithMany()
                 .HasForeignKey("ColorsId")
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // Cannot delete a Material if it's used by any Furniture 
            modelBuilder.Entity("FurnitureMaterial", b =>
            {
                b.HasOne(typeof(Furniture), null)
                 .WithMany()
                 .HasForeignKey("FurnituresId")
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(typeof(Material), null)
                 .WithMany()
                 .HasForeignKey("MaterialsId")
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // Cannot delete a Type, Room or Brand if it's used by any Furniture
            modelBuilder.Entity<Furniture>(entity =>
            {
                entity.HasOne(f => f.FType).WithMany().HasForeignKey(f => f.TypeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(f => f.Room).WithMany().HasForeignKey(f => f.RoomId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(f => f.Brand).WithMany().HasForeignKey(f => f.BrandId).OnDelete(DeleteBehavior.Restrict);
            });

            // If User is deleted, delete their Catalogs
            modelBuilder.Entity<Catalog>()
                .HasOne(c => c.ApplicationUser).WithMany(u => u.Catalogs).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FType>().HasData(
                new FType { Id = 1, Name = "Маса" },
                new FType { Id = 2, Name = "Стол" },
                new FType { Id = 3, Name = "Диван" },
                new FType { Id = 4, Name = "Легло" },
                new FType { Id = 5, Name = "Секция" },
                new FType { Id = 6, Name = "Бюро" },
                new FType { Id = 7, Name = "Шкаф" },
                new FType { Id = 8, Name = "Кресло" },
                new FType { Id = 9, Name = "Полица" },
                new FType { Id = 10, Name = "Огледало" },
                new FType { Id = 11, Name = "Табуретка" },
                new FType { Id = 12, Name = "Гардероб" },
                new FType { Id = 13, Name = "Кухненски шкаф" },
                new FType { Id = 14, Name = "Бар стол" },
                new FType { Id = 15, Name = "Трапезен комплект" },
                new FType { Id = 16, Name = "Нощно шкафче" },
                new FType { Id = 17, Name = "TV Шкаф" },
                new FType { Id = 18, Name = "Холна маса" },
                new FType { Id = 19, Name = "Библиотека" },
                new FType { Id = 20, Name = "Закачалка" },
                new FType { Id = 21, Name = "Градинска маса" },
                new FType { Id = 22, Name = "Шезлонг" },
                new FType { Id = 23, Name = "Детско легло" },
                new FType { Id = 24, Name = "Скрин" },
                new FType { Id = 25, Name = "Компютърен стол" },
                new FType { Id = 26, Name = "Офис шкаф" },
                new FType { Id = 27, Name = "Ъглов диван" }
                );

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "IKEA" },
                new Brand { Id = 2, Name = "JYSK" },
                new Brand { Id = 3, Name = "Leroy Merlin" },
                new Brand { Id = 4, Name = "HomeMax" },
                new Brand { Id = 5, Name = "Bauhaus" },
                new Brand { Id = 6, Name = "Mr. Bricolage" },
                new Brand { Id = 7, Name = "Praktiker" }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Всекидневна" },
                new Room { Id = 2, Name = "Спалня" },
                new Room { Id = 3, Name = "Кухня" },
                new Room { Id = 4, Name = "Трапезария" },
                new Room { Id = 5, Name = "Баня" },
                new Room { Id = 6, Name = "Офис" },
                new Room { Id = 7, Name = "Детска стая" },
                new Room { Id = 8, Name = "Градина" },
                new Room { Id = 9, Name = "Други" }
            );

            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 1, Name = "Дърво" },
                new Material { Id = 2, Name = "Метал" },
                new Material { Id = 3, Name = "Пластмаса" },
                new Material { Id = 4, Name = "Стъкло" },
                new Material { Id = 5, Name = "Текстил" },
                new Material { Id = 6, Name = "Кожа" },
                new Material { Id = 7, Name = "Мрамор" },
                new Material { Id = 8, Name = "Гранитогрес" },
                new Material { Id = 9, Name = "Други" }
            );

            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Бял" },
                new Color { Id = 2, Name = "Черен" },
                new Color { Id = 3, Name = "Сив" },
                new Color { Id = 4, Name = "Червен" },
                new Color { Id = 5, Name = "Син" },
                new Color { Id = 6, Name = "Зелен" },
                new Color { Id = 7, Name = "Жълт" },
                new Color { Id = 8, Name = "Кафяв" },
                new Color { Id = 9, Name = "Оранжев" },
                new Color { Id = 10, Name = "Лилав" },
                new Color { Id = 11, Name = "Розов" },
                new Color { Id = 12, Name = "Бежов" },
                new Color { Id = 13, Name = "Други" }
            );

            modelBuilder.Entity<Furniture>().HasData(
                new Furniture { Id = 1, Photo = "furniture1.png", Name = "'Виктория'", BrandId = 4, RoomId = 9, Length = 227.3, Width = 120.3, Height = 100.8, ProductionYear = 2018, TypeId = 3 },
                new Furniture { Id = 2, Photo = "furniture2.png", Name = "'Овал'", BrandId = 7, RoomId = 8, Length = 288.7, Width = 63.8, Height = 111.4, ProductionYear = 2016, TypeId = 1 },
                new Furniture { Id = 3, Photo = "furniture3.png", Name = "'Класик'", BrandId = 1, RoomId = 2, Length = 100.1, Width = 60.1, Height = 120.5, ProductionYear = 2021, TypeId = 2 },
                new Furniture { Id = 4, Photo = "furniture4.png", Name = "'Елеганс'", BrandId = 6, RoomId = 2, Length = 230.1, Width = 110.5, Height = 105.1, ProductionYear = 2022, TypeId = 4 },
                new Furniture { Id = 5, Photo = "furniture5.png", Name = "'Модерн'", BrandId = 1, RoomId = 4, Length = 150.5, Width = 40.5, Height = 210.1, ProductionYear = 2020, TypeId = 5 },
                new Furniture { Id = 6, Photo = "furniture6.png", Name = "'Работно'", BrandId = 3, RoomId = 6, Length = 140.2, Width = 70.1, Height = 75.0, ProductionYear = 2024, TypeId = 6 },
                new Furniture { Id = 7, Photo = "furniture7.png", Name = "'Компакт'", BrandId = 5, RoomId = 7, Length = 80.0, Width = 45.5, Height = 180.3, ProductionYear = 2019, TypeId = 7 },
                new Furniture { Id = 8, Photo = "furniture8.png", Name = "'Релакс'", BrandId = 2, RoomId = 1, Length = 90.5, Width = 95.5, Height = 110.1, ProductionYear = 2021, TypeId = 8 },
                new Furniture { Id = 9, Photo = "furniture9.png", Name = "'Минимал'", BrandId = 7, RoomId = 9, Length = 120.0, Width = 25.0, Height = 60.0, ProductionYear = 2022, TypeId = 9 },
                new Furniture { Id = 10, Photo = "furniture10.png", Name = "'Кръг'", BrandId = 1, RoomId = 5, Length = 80.0, Width = 3.0, Height = 80.0, ProductionYear = 2023, TypeId = 10 },
                new Furniture { Id = 11, Photo = "furniture11.png", Name = "'Пуф'", BrandId = 2, RoomId = 1, Length = 40.0, Width = 40.0, Height = 45.0, ProductionYear = 2024, TypeId = 11 },
                new Furniture { Id = 12, Photo = "furniture12.png", Name = "'Сити'", BrandId = 3, RoomId = 2, Length = 200.0, Width = 60.0, Height = 220.0, ProductionYear = 2017, TypeId = 12 },
                new Furniture { Id = 13, Photo = "furniture13.png", Name = "Стандарт", BrandId = 4, RoomId = 3, Length = 100.0, Width = 50.0, Height = 85.0, ProductionYear = 2020, TypeId = 13 },
                new Furniture { Id = 14, Photo = "furniture14.png", Name = "Висок", BrandId = 1, RoomId = 3, Length = 45.0, Width = 45.0, Height = 100.0, ProductionYear = 2021, TypeId = 14 },
                new Furniture { Id = 15, Photo = "furniture15.png", Name = "Лукс", BrandId = 5, RoomId = 4, Length = 160.0, Width = 90.0, Height = 75.0, ProductionYear = 2022, TypeId = 15 },
                new Furniture { Id = 16, Photo = "furniture16.png", Name = "Малко", BrandId = 6, RoomId = 2, Length = 50.0, Width = 40.0, Height = 55.0, ProductionYear = 2023, TypeId = 16 },
                new Furniture { Id = 17, Photo = "furniture17.png", Name = "Слим", BrandId = 7, RoomId = 1, Length = 180.0, Width = 45.0, Height = 50.0, ProductionYear = 2019, TypeId = 17 },
                new Furniture { Id = 18, Photo = "furniture18.png", Name = "Ниска", BrandId = 1, RoomId = 1, Length = 100.0, Width = 60.0, Height = 45.0, ProductionYear = 2020, TypeId = 18 },
                new Furniture { Id = 19, Photo = "furniture19.png", Name = "Класика", BrandId = 2, RoomId = 6, Length = 80.0, Width = 30.0, Height = 200.0, ProductionYear = 2021, TypeId = 19 },
                new Furniture { Id = 20, Photo = "furniture20.png", Name = "Стенна", BrandId = 3, RoomId = 9, Length = 50.0, Width = 50.0, Height = 180.0, ProductionYear = 2022, TypeId = 20 },
                new Furniture { Id = 21, Photo = "furniture21.png", Name = "Дървена", BrandId = 4, RoomId = 8, Length = 140.0, Width = 80.0, Height = 70.0, ProductionYear = 2023, TypeId = 21 },
                new Furniture { Id = 22, Photo = "furniture22.png", Name = "Плажен", BrandId = 5, RoomId = 8, Length = 190.0, Width = 70.0, Height = 35.0, ProductionYear = 2024, TypeId = 22 },
                new Furniture { Id = 23, Photo = "furniture23.png", Name = "Бебешко", BrandId = 6, RoomId = 7, Length = 160.0, Width = 80.0, Height = 60.0, ProductionYear = 2020, TypeId = 23 },
                new Furniture { Id = 24, Photo = "furniture24.png", Name = "Широк", BrandId = 7, RoomId = 2, Length = 120.0, Width = 45.0, Height = 80.0, ProductionYear = 2021, TypeId = 24 },
                new Furniture { Id = 25, Photo = "furniture25.png", Name = "Ергономичен", BrandId = 1, RoomId = 6, Length = 60.0, Width = 60.0, Height = 120.0, ProductionYear = 2022, TypeId = 25 },
                new Furniture { Id = 26, Photo = "furniture26.png", Name = "Метален", BrandId = 2, RoomId = 6, Length = 80.0, Width = 40.0, Height = 180.0, ProductionYear = 2023, TypeId = 26 },
                new Furniture { Id = 27, Photo = "furniture27.png", Name = "Голям", BrandId = 3, RoomId = 1, Length = 280.0, Width = 180.0, Height = 85.0, ProductionYear = 2018, TypeId = 27 },
                new Furniture { Id = 28, Photo = "furniture28.png", Name = "Висящ", BrandId = 4, RoomId = 9, Length = 100.0, Width = 20.0, Height = 150.0, ProductionYear = 2019, TypeId = 9 },
                new Furniture { Id = 29, Photo = "furniture29.png", Name = "Градинска", BrandId = 5, RoomId = 8, Length = 120.0, Width = 40.0, Height = 45.0, ProductionYear = 2020, TypeId = 21 },
                new Furniture { Id = 30, Photo = "furniture30.png", Name = "С огледало", BrandId = 6, RoomId = 2, Length = 90.0, Width = 40.0, Height = 140.0, ProductionYear = 2021, TypeId = 24 }
            );

            modelBuilder.Entity("ColorFurniture").HasData(
                new { FurnituresId = 1, ColorsId = 12 },
                new { FurnituresId = 1, ColorsId = 8 },

                new { FurnituresId = 2, ColorsId = 1 },
                new { FurnituresId = 2, ColorsId = 8 },

                new { FurnituresId = 3, ColorsId = 2 },
                new { FurnituresId = 3, ColorsId = 3 },

                new { FurnituresId = 4, ColorsId = 1 },
                new { FurnituresId = 4, ColorsId = 12 },
                new { FurnituresId = 4, ColorsId = 8 },

                new { FurnituresId = 5, ColorsId = 8 },
                new { FurnituresId = 5, ColorsId = 3 },

                new { FurnituresId = 6, ColorsId = 3 },
                new { FurnituresId = 6, ColorsId = 1 },

                new { FurnituresId = 7, ColorsId = 12 },
                new { FurnituresId = 7, ColorsId = 8 },

                new { FurnituresId = 8, ColorsId = 1 },
                new { FurnituresId = 8, ColorsId = 12 },
                new { FurnituresId = 8, ColorsId = 3 },

                new { FurnituresId = 9, ColorsId = 12 },
                new { FurnituresId = 9, ColorsId = 8 },

                new { FurnituresId = 10, ColorsId = 1 },

                new { FurnituresId = 11, ColorsId = 11 },
                new { FurnituresId = 11, ColorsId = 1 },
                new { FurnituresId = 11, ColorsId = 12 },

                new { FurnituresId = 12, ColorsId = 3 },
                new { FurnituresId = 12, ColorsId = 1 },

                new { FurnituresId = 13, ColorsId = 2 },
                new { FurnituresId = 13, ColorsId = 8 },
                new { FurnituresId = 13, ColorsId = 3 },

                new { FurnituresId = 14, ColorsId = 8 },

                new { FurnituresId = 15, ColorsId = 1 },
                new { FurnituresId = 15, ColorsId = 3 },
                new { FurnituresId = 15, ColorsId = 12 },

                new { FurnituresId = 16, ColorsId = 3 },
                new { FurnituresId = 16, ColorsId = 12 },

                new { FurnituresId = 17, ColorsId = 8 },
                new { FurnituresId = 17, ColorsId = 1 },

                new { FurnituresId = 18, ColorsId = 3 },
                new { FurnituresId = 18, ColorsId = 1 },

                new { FurnituresId = 19, ColorsId = 5 },
                new { FurnituresId = 19, ColorsId = 3 },
                new { FurnituresId = 19, ColorsId = 12 },

                new { FurnituresId = 20, ColorsId = 1 },
                new { FurnituresId = 20, ColorsId = 8 },
                new { FurnituresId = 20, ColorsId = 3 },

                new { FurnituresId = 21, ColorsId = 12 },
                new { FurnituresId = 21, ColorsId = 1 },

                new { FurnituresId = 22, ColorsId = 12 },
                new { FurnituresId = 22, ColorsId = 5 },
                new { FurnituresId = 22, ColorsId = 3 },

                new { FurnituresId = 23, ColorsId = 12 },
                new { FurnituresId = 23, ColorsId = 1 },
                new { FurnituresId = 23, ColorsId = 11 },

                new { FurnituresId = 24, ColorsId = 8 },
                new { FurnituresId = 24, ColorsId = 12 },

                new { FurnituresId = 25, ColorsId = 2 },
                new { FurnituresId = 25, ColorsId = 3 },

                new { FurnituresId = 26, ColorsId = 1 },
                new { FurnituresId = 26, ColorsId = 8 },

                new { FurnituresId = 27, ColorsId = 12 },
                new { FurnituresId = 27, ColorsId = 1 },
                new { FurnituresId = 27, ColorsId = 3 },
                new { FurnituresId = 27, ColorsId = 8 },

                new { FurnituresId = 28, ColorsId = 1 },
                new { FurnituresId = 28, ColorsId = 12 },

                new { FurnituresId = 29, ColorsId = 8 },
                new { FurnituresId = 29, ColorsId = 12 },

                new { FurnituresId = 30, ColorsId = 12 },
                new { FurnituresId = 30, ColorsId = 1 },
                new { FurnituresId = 30, ColorsId = 3 }
            );

            modelBuilder.Entity("FurnitureMaterial").HasData(
                new { FurnituresId = 1, MaterialsId = 5 },
                new { FurnituresId = 1, MaterialsId = 1 },

                new { FurnituresId = 2, MaterialsId = 1 },
                new { FurnituresId = 2, MaterialsId = 2 },
                new { FurnituresId = 2, MaterialsId = 7 },

                new { FurnituresId = 3, MaterialsId = 3 },
                new { FurnituresId = 3, MaterialsId = 2 },

                new { FurnituresId = 4, MaterialsId = 1 },
                new { FurnituresId = 4, MaterialsId = 9 },

                new { FurnituresId = 5, MaterialsId = 1 },

                new { FurnituresId = 6, MaterialsId = 1 },
                new { FurnituresId = 6, MaterialsId = 2 },
                new { FurnituresId = 6, MaterialsId = 4 },

                new { FurnituresId = 7, MaterialsId = 7 },
                new { FurnituresId = 7, MaterialsId = 1 },

                new { FurnituresId = 8, MaterialsId = 1 },
                new { FurnituresId = 8, MaterialsId = 6 },

                new { FurnituresId = 9, MaterialsId = 1 },
                new { FurnituresId = 9, MaterialsId = 5 },

                new { FurnituresId = 10, MaterialsId = 4 },
                new { FurnituresId = 10, MaterialsId = 3 },

                new { FurnituresId = 11, MaterialsId = 5 },
                new { FurnituresId = 11, MaterialsId = 1 },

                new { FurnituresId = 12, MaterialsId = 1 },

                new { FurnituresId = 13, MaterialsId = 1 },
                new { FurnituresId = 13, MaterialsId = 2 },
                new { FurnituresId = 13, MaterialsId = 6 },

                new { FurnituresId = 14, MaterialsId = 6 },
                new { FurnituresId = 14, MaterialsId = 2 },

                new { FurnituresId = 15, MaterialsId = 1 },
                new { FurnituresId = 15, MaterialsId = 4 },
                new { FurnituresId = 15, MaterialsId = 8 },

                new { FurnituresId = 16, MaterialsId = 1 },
                new { FurnituresId = 16, MaterialsId = 3 },

                new { FurnituresId = 17, MaterialsId = 1 },
                new { FurnituresId = 17, MaterialsId = 2 },

                new { FurnituresId = 18, MaterialsId = 1 },
                new { FurnituresId = 18, MaterialsId = 9 },

                new { FurnituresId = 19, MaterialsId = 5 },
                new { FurnituresId = 19, MaterialsId = 1 },

                new { FurnituresId = 20, MaterialsId = 1 },
                new { FurnituresId = 20, MaterialsId = 2 },

                new { FurnituresId = 21, MaterialsId = 1 },
                new { FurnituresId = 21, MaterialsId = 8 },

                new { FurnituresId = 22, MaterialsId = 6 },
                new { FurnituresId = 22, MaterialsId = 1 },

                new { FurnituresId = 23, MaterialsId = 1 },
                new { FurnituresId = 23, MaterialsId = 5 },

                new { FurnituresId = 24, MaterialsId = 1 },

                new { FurnituresId = 25, MaterialsId = 2 },
                new { FurnituresId = 25, MaterialsId = 3 },

                new { FurnituresId = 26, MaterialsId = 2 },
                new { FurnituresId = 26, MaterialsId = 1 },

                new { FurnituresId = 27, MaterialsId = 5 },
                new { FurnituresId = 27, MaterialsId = 1 },
                new { FurnituresId = 27, MaterialsId = 2 },

                new { FurnituresId = 28, MaterialsId = 1 },
                new { FurnituresId = 28, MaterialsId = 4 },

                new { FurnituresId = 29, MaterialsId = 1 },
                new { FurnituresId = 29, MaterialsId = 7 },

                new { FurnituresId = 30, MaterialsId = 1 },
                new { FurnituresId = 30, MaterialsId = 6 }
            );

        }
    }
}