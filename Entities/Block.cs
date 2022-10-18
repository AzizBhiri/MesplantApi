using System;

namespace MesplantApi.Entities
{
    public record Block
    {
        public Guid id { get; init; }
        public bool isRunning { get; init; }
        public Guid downtimeTypeId { get; init; }
        public DateTimeOffset startedAt { get; init; }
        public DateTimeOffset finishedAt { get; init; }
        public Guid productId { get; init; }
        public int valid { get; set; }
        public int scrap { get; set; }
        public string downtimeTypeName { get; set; }
        public string productName { get; set; }
    }
}