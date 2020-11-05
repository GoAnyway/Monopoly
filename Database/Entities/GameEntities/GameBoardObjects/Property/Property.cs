namespace Database.Entities.GameEntities.GameBoardObjects.Property
{
    /// <summary>
    /// </summary>
    public class Property
    {
        public PropertyType PropertyType { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int BaseTax { get; set; }
        public Player Owner { get; set; }
        public Level UpgradeLevel { get; set; }
    }
}