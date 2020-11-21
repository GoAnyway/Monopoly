using System.Collections.Generic;
using Database.Entities.GameEntities.GameBoardObjects;
using Database.Entities.GameEntities.GameBoardObjects.Default;
using Database.Entities.GameEntities.GameBoardObjects.PropertyEntities;
using Database.Entities.GameEntities.GameBoardObjects.PropertyEntities.Enums;

namespace Database
{
    public static class CellSeed
    {
        public static IEnumerable<Cell> GetCellsToSeed() =>
            new Cell[]
            {
                new Start {Index = 0},

                new Property(PropertyType.Pink, "Chanel", 600000, 20000) {Index = 1},
                new Chance {Index = 2},
                new Property(PropertyType.Pink, "Hugo Boss", 600000, 40000) {Index = 3},
                new Payment(2000000) {Index = 4},
                new Communication(PropertyType.Red, "Mercedes-Benz", 2000000, 250000) {Index = 5},
                new Property(PropertyType.Orange, "Adidas", 1000000, 60000) {Index = 6},
                new Chance {Index = 7},
                new Property(PropertyType.Orange, "Puma", 1000000, 60000) {Index = 8},
                new Property(PropertyType.Orange, "Lacoste", 1200000, 80000) {Index = 9},

                new Jail {Index = 10},

                new Property(PropertyType.Cyan, "VK", 1400000, 100000) {Index = 11},
                new Infrastructure(PropertyType.DarkRed, "Reuters", 1500000, 1000) {Index = 12},
                new Property(PropertyType.Cyan, "Facebook", 1400000, 100000) {Index = 13},
                new Property(PropertyType.Cyan, "Tweeter", 1600000, 120000) {Index = 14},
                new Communication(PropertyType.Red, "Audi", 2000000, 250000) {Index = 15},
                new Property(PropertyType.Yellow, "Coca-Cola", 1800000, 140000) {Index = 16},
                new Chance {Index = 17},
                new Property(PropertyType.Yellow, "Pepsi", 1800000, 140000) {Index = 18},
                new Property(PropertyType.Yellow, "Fanta", 2000000, 160000) {Index = 19},

                new Jackpot {Index = 20},

                new Property(PropertyType.Green, "American Airlines", 2200000, 180000) {Index = 21},
                new Chance {Index = 22},
                new Property(PropertyType.Green, "Lufthansa", 2200000, 180000) {Index = 23},
                new Property(PropertyType.Green, "British Airlines", 2400000, 200000) {Index = 24},
                new Communication(PropertyType.Red, "Ford", 2000000, 250000) {Index = 25},
                new Property(PropertyType.LightBlue, "McDonald’s", 2600000, 220000) {Index = 26},
                new Property(PropertyType.LightBlue, "Burger King", 2600000, 220000) {Index = 27},
                new Infrastructure(PropertyType.DarkRed, "AMBS Architects", 1500000, 1000) {Index = 28},
                new Property(PropertyType.LightBlue, "KFC", 2800000, 240000) {Index = 29},

                new Police {Index = 30},

                new Property(PropertyType.Purple, "Holiday Inn", 3000000, 260000) {Index = 31},
                new Property(PropertyType.Purple, "Radisson", 3000000, 260000) {Index = 32},
                new Chance {Index = 33},
                new Property(PropertyType.Purple, "Novotel", 3200000, 280000) {Index = 34},
                new Communication(PropertyType.Red, "Land-Rover", 2000000, 250000) {Index = 35},
                new Payment(1000000) {Index = 36},
                new Property(PropertyType.DarkBlue, "Apple", 3500000, 350000) {Index = 37},
                new Chance {Index = 38},
                new Property(PropertyType.DarkBlue, "Nokia", 4000000, 500000) {Index = 39}
            };
    }
}