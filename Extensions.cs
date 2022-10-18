using MesplantApi.Dtos;
using MesplantApi.Entities;

namespace MesplantApi
{
    public static class Extensions
    {
        public static BlockDto AsDto(this Block block)
        {
            return new BlockDto
            {
                id = block.id,
                isRunning = block.isRunning,
                downtimeTypeId = block.downtimeTypeId,
                startedAt = block.startedAt,
                finishedAt = block.finishedAt,
                productId = block.productId,
                valid = block.valid,
                scrap = block.scrap,
                downtimeTypeName = block.downtimeTypeName,
                productName = block.productName
            };
        }
    }
}