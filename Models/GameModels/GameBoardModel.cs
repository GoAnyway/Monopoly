using System.Collections.Generic;
using Models.GameModels.CellModels;

namespace Models.GameModels
{
    public class GameBoardModel
    {
        public GameBoardModel(ICollection<CellModel> cells)
        {
            Cells = cells;
        }

        public ICollection<CellModel> Cells { get; set; } 
    }
}