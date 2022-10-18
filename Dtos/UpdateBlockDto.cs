using System;
using System.ComponentModel.DataAnnotations;

namespace MesplantApi.Dtos
{
    public record UpdateBlockDto
    {
        [Required]
        public bool isRunning { get; init; }
        [Required]
        public DateTimeOffset startedAt { get; init; }
        [Required]
        public DateTimeOffset finishedAt { get; init; }
        [Required]
        [Range(0, 1_000_000)]
        public int valid { get; set; }
        [Required]
        [Range(0, 1_000_000)]
        public int scrap { get; set; }
        public string downtimeTypeName { get; set; }
        public string productName { get; set; }
    }
}