using Models.GameModels.CellModels.PropertyEnums;

namespace Models.GameModels.CellModels
{
    public class PropertyModel : CellModel
    {
        public PropertyType PropertyType { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int BaseTax { get; set; }
        public PlayerModel Owner { get; set; }
        public Level UpgradeLevel { get; set; }
    }
}