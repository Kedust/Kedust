using System.Collections.Generic;
using Kedust.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kedust.Data.Dal
{
    public static class SeedDevData
    {
        public static ModelBuilder Seed(this ModelBuilder builder) => builder.SeedMenu().SeedTable();

        private static ModelBuilder SeedMenu(this ModelBuilder builder)
        {
            builder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = -2,
                    Name = "Normaal"
                }, new Menu
                {
                    Id = -1,
                    Name = "VIP"
                }
            );
            builder.Entity<Choice>().HasData(
                //NORMAL MENU
                new Choice
                {
                    Id = -1,
                    Name = "Plat water",
                    Price = 1.6m,
                    Sorting = 1,
                    MenuId = -2
                }, new Choice
                {
                    Id = -2,
                    Name = "Spuitwater",
                    Price = 1.6m,
                    Sorting = 2,
                    MenuId = -2
                }, new Choice
                {
                    Id = -3,
                    Name = "Cola",
                    Price = 1.6m,
                    Sorting = 3,
                    MenuId = -2
                }, new Choice
                {
                    Id = -4,
                    Name = "Jupiler",
                    Price = 1.6m,
                    Sorting = 4,
                    MenuId = -2
                },
                //VIP MENU
                new Choice
                {
                    Id = -5,
                    Name = "Plat water",
                    Price = 1.6m,
                    Sorting = 1,
                    MenuId = -1
                }, new Choice
                {
                    Id = -6,
                    Name = "Spuitwater",
                    Price = 1.6m,
                    Sorting = 2,
                    MenuId = -1
                }, new Choice
                {
                    Id = -7,
                    Name = "Cola",
                    Price = 1.6m,
                    Sorting = 3,
                    MenuId = -1
                }, new Choice
                {
                    Id = -8,
                    Name = "Jupiler",
                    Price = 1.6m,
                    Sorting = 4,
                    MenuId = -1
                }, new Choice
                {
                    Id = -9,
                    Name = "Omer",
                    Price = 2.0m,
                    Sorting = 5,
                    MenuId = -1
                }, new Choice
                {
                    Id = -10,
                    Name = "Cava",
                    Price = 3.2m,
                    Sorting = 6,
                    MenuId = -1
                });
            return builder;
        }

        private static ModelBuilder SeedTable(this ModelBuilder builder)
        {
            builder.Entity<Table>().HasData(
                new Table
                {
                    Id = -10,
                    Code = "azerty",
                    Description = "Tafel 11",
                    MenuId = -100
                }, new Table
                {
                    Id = -9,
                    Code = "fjkeeo",
                    Description = "Tafel 12",
                    MenuId = -100
                }, new Table
                {
                    Id = -8,
                    Code = "fkleid",
                    Description = "Tafel 13",
                    MenuId = -100
                }, new Table
                {
                    Id = -7,
                    Code = "xhekfo",
                    Description = "Tafel 14",
                    MenuId = -100
                }, new Table
                {
                    Id = -6,
                    Code = "mzcihr",
                    Description = "Tafel 15",
                    MenuId = -100
                }, new Table
                {
                    Id = -5,
                    Code = "tjvkdp",
                    Description = "Tafel 21",
                    MenuId = -100
                }, new Table
                {
                    Id = -4,
                    Code = "dlpzhc",
                    Description = "Tafel 22",
                    MenuId = -100
                }, new Table
                {
                    Id = -3,
                    Code = "mlifsq",
                    Description = "Tafel 23",
                    MenuId = -100
                }, new Table
                {
                    Id = -2,
                    Code = "qfinwb",
                    Description = "Tafel 24",
                    MenuId = -100
                }, new Table
                {
                    Id = -1,
                    Code = "pmoeng",
                    Description = "Tafel 25",
                    MenuId = -100
                }
            );

            return builder;
        }
    }
}