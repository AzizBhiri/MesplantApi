using MesplantApi.Dtos;
using MesplantApi.Entities;
using MesplantApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MesplantApi.Controllers
{
    [ApiController]
    [Route("blocks")]
    public class BlocksController : ControllerBase
    {
        private readonly IBlocksRepository repository;

        public BlocksController(IBlocksRepository repository)
        {
            this.repository = repository;
        }

        // GET /blocks
        [HttpGet]
        public async Task<IEnumerable<BlockDto>> GetBlocksAsync()
        {
            var blocks = (await repository.GetBlocksAsync())
                        .Select(block => block.AsDto());
            return blocks;
        }

        // GET /block/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BlockDto>> GetBlockAsync(Guid id)
        {
            var block = await repository.GetBlockAsync(id);

            if (block is null)
            {
                return NotFound();
            }
            return block.AsDto();
        }

        // POST /block
        [HttpPost]
        public async Task<ActionResult<BlockDto>> CreateBlockAsync(CreateBlockDto blockDto)
        {
            Block block = new()
            {
                id = Guid.NewGuid(),
                isRunning = blockDto.isRunning,
                downtimeTypeId = Guid.NewGuid(),
                startedAt = blockDto.startedAt,
                finishedAt = blockDto.finishedAt,
                productId = Guid.NewGuid(),
                valid = blockDto.valid,
                scrap = blockDto.scrap,
                downtimeTypeName = blockDto.downtimeTypeName,
                productName = blockDto.productName
            };

            await repository.CreateBlockAsync(block);

            return CreatedAtAction(nameof(GetBlockAsync), new { id = block.id }, block.AsDto());
        }

        // PUT /blocks/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBlockAsync(Guid id, UpdateBlockDto blockDto)
        {
            var exsistingBlock = await repository.GetBlockAsync(id);

            if (exsistingBlock is null)
            {
                return NotFound();
            }

            Block updatedBlock = exsistingBlock with
            {
                isRunning = blockDto.isRunning,
                finishedAt = blockDto.finishedAt,
                valid = blockDto.valid,
                scrap = blockDto.scrap,
                downtimeTypeName = blockDto.downtimeTypeName,
                productName = blockDto.productName
            };

            await repository.UpdateBlockAsync(updatedBlock);
            return NoContent();
        }

        // DELETE /blocks/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlockAsync(Guid id)
        {
            var exsistingBlock = await repository.GetBlockAsync(id);

            if (exsistingBlock is null)
            {
                return NotFound();
            }

            await repository.DeleteBlockAsync(id);
            return NoContent();
        }
    }
}