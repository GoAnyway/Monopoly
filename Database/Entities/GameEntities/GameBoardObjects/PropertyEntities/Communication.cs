using System;
using Database.Entities.GameEntities.GameBoardObjects.PropertyEntities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Database.Entities.GameEntities.GameBoardObjects.PropertyEntities
{
    [Owned]
    public class Communication : Property
    {
        public Communication(PropertyType propertyType, string name, int cost, int baseTax)
            : base(propertyType, name, cost, baseTax)
        {

        }

        public int Multiplier { get; set; }

        public override int Tax =>
            UpgradeLevel switch
            {
                Level.First => BaseTax * 100 * Multiplier,
                Level.Second => BaseTax * 250 * Multiplier,
                _ => throw new ArgumentOutOfRangeException()
            };

        public override Level UpgradeLevel { get; set; } = Level.First;
    }
}