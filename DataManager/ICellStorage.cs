using System.Collections.Generic;
using System.Threading.Tasks;
using Models.GameModels.CellModels;

namespace DataManager
{
    //TODO 3: Implement this service
    public interface ICellStorage
    {
        Task<ICollection<CellModel>> GetCells();
    }
}