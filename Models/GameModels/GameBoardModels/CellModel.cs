using System.Collections.Generic;

namespace Models.GameModels.CellModels
{
    public abstract class CellModel
    {
        public int Index { get; set; }
        public ICollection<PlayerModel> Players { get; set; }
    }
}