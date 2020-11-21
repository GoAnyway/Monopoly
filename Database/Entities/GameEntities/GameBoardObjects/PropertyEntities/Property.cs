using System;
using Database.Entities.GameEntities.GameBoardObjects.PropertyEntities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Database.Entities.GameEntities.GameBoardObjects.PropertyEntities
{
    [Owned]
    public class Property : Cell
    {
        public Property(PropertyType propertyType, string name, int cost, int baseTax)
        {
            PropertyType = propertyType;
            Name = name;
            Cost = cost;
            BaseTax = baseTax;
        }

        public PropertyType PropertyType { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public virtual int Tax =>
            UpgradeLevel switch
            {
                Level.Zero => BaseTax,
                Level.First => BaseTax * 5,
                Level.Second => BaseTax * 15,
                Level.Third => BaseTax * 45,
                Level.Fourth => BaseTax * 60,
                Level.Hotel => BaseTax * 75,
                _ => throw new ArgumentOutOfRangeException()
            };
        public int BaseTax { get; set; }
        public int Deposit => Cost / 2;
        public int Redemption => (int)(Deposit * 1.2);
        public int UpgradeCost { get; set; }
        public Player Owner { get; set; }
        public virtual Level UpgradeLevel { get; set; } = Level.Zero;
    }
}