using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MesplantApi.Entities;

namespace MesplantApi.Repositories
{
    public interface IBlocksRepository
    {
        Task<Block> GetBlockAsync(Guid id);
        Task<IEnumerable<Block>> GetBlocksAsync();
        Task CreateBlockAsync(Block block);
        Task UpdateBlockAsync(Block block);
        Task DeleteBlockAsync(Guid id);
    }
}