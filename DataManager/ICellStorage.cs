using System.Collections.Generic;
using System.Threading.Tasks;
using Models.GameModels.CellModels;

namespace DataManager
{
    public interface ICellStorage
    {
        Task<ICollection<CellModel>> GetCells();
    }
}