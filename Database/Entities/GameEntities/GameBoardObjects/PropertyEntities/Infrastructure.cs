using System;
using Database.Entities.GameEntities.GameBoardObjects.PropertyEntities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Database.Entities.GameEntities.GameBoardObjects.PropertyEntities
{
    [Owned]
    public class Infrastructure : Property
    {
        public Infrastructure(PropertyType propertyType, string name, int cost, int baseTax)
            : base(propertyType, name, cost, baseTax)
        {

        }

        public override int Tax =>
            UpgradeLevel switch
            {
                Level.First => BaseTax,
                Level.Second => BaseTax * 2,
                Level.Third => BaseTax * 3,
                Level.Fourth => BaseTax * 4,
                _ => throw new ArgumentOutOfRangeException()
            };

        public override Level UpgradeLevel { get; set; } = Level.First;
    }
}