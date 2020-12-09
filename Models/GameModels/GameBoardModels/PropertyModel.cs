using System;
using Models.GameModels.CellModels.PropertyEnums;

namespace Models.GameModels.CellModels
{
    public class PropertyModel : CellModel
    {
        public PropertyType PropertyType { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Tax =>
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
        public int Redemption => (int) (Deposit * 1.2);
        public int UpgradeCost { get; set; }
        public PlayerModel Owner { get; set; }
        public Level UpgradeLevel { get; set; }
    }
}