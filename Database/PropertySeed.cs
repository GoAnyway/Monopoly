using System.Collections.Generic;
using Database.Entities.GameBoardObjects.Property;

namespace Database
{
    internal class PropertySeed
    {
        public IEnumerable<Property> GetPropertiesToSeed()
        {
            return new List<Property>
            {
                new Property
                {
                    PropertyType = PropertyType.Pink, Name = "Chanel", Cost = 600000, BaseTax = 20000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Pink, Name = "Hugo Boss", Cost = 600000, BaseTax = 40000,
                    UpgradeLevel = Level.Zero
                },

                new Property
                {
                    PropertyType = PropertyType.Orange, Name = "Adidas", Cost = 1000000, BaseTax = 60000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Orange, Name = "Puma", Cost = 1000000, BaseTax = 60000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Orange, Name = "Lacoste", Cost = 1200000, BaseTax = 80000,
                    UpgradeLevel = Level.Zero
                },

                new Property
                {
                    PropertyType = PropertyType.Cyan, Name = "VK", Cost = 1400000, BaseTax = 100000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Cyan, Name = "Facebook", Cost = 1400000, BaseTax = 100000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Cyan, Name = "Tweeter", Cost = 1600000, BaseTax = 120000,
                    UpgradeLevel = Level.Zero
                },

                new Property
                {
                    PropertyType = PropertyType.Yellow, Name = "Coca-Cola", Cost = 1800000, BaseTax = 140000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Yellow, Name = "Pepsi", Cost = 1800000, BaseTax = 140000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Yellow, Name = "Fanta", Cost = 2000000, BaseTax = 160000,
                    UpgradeLevel = Level.Zero
                },

                new Property
                {
                    PropertyType = PropertyType.Green, Name = "American Airlines", Cost = 2200000, BaseTax = 180000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Green, Name = "Lufthansa", Cost = 2200000, BaseTax = 180000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Green, Name = "British Airlines", Cost = 2400000, BaseTax = 200000,
                    UpgradeLevel = Level.Zero
                },

                new Property
                {
                    PropertyType = PropertyType.LightBlue, Name = "McDonald’s", Cost = 2600000, BaseTax = 220000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.LightBlue, Name = "Burger King", Cost = 2600000, BaseTax = 220000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.LightBlue, Name = "KFC", Cost = 2800000, BaseTax = 240000,
                    UpgradeLevel = Level.Zero
                },

                new Property
                {
                    PropertyType = PropertyType.Purple, Name = "Holiday Inn", Cost = 3000000, BaseTax = 260000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Purple, Name = "Radisson", Cost = 3000000, BaseTax = 260000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Purple, Name = "Novotel", Cost = 3200000, BaseTax = 280000,
                    UpgradeLevel = Level.Zero
                },

                new Property
                {
                    PropertyType = PropertyType.DarkBlue, Name = "Apple", Cost = 3500000, BaseTax = 350000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.DarkBlue, Name = "Nokia", Cost = 4000000, BaseTax = 500000,
                    UpgradeLevel = Level.Zero
                },

                new Property
                {
                    PropertyType = PropertyType.Red, Name = "Mercedes-Benz", Cost = 2000000, BaseTax = 250000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Red, Name = "Audi", Cost = 2000000, BaseTax = 250000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Red, Name = "Ford", Cost = 2000000, BaseTax = 250000,
                    UpgradeLevel = Level.Zero
                },
                new Property
                {
                    PropertyType = PropertyType.Red, Name = "Land-Rover", Cost = 2000000, BaseTax = 250000,
                    UpgradeLevel = Level.Zero
                }
            };
        }
    }
}