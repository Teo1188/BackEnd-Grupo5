using System;

namespace ExtraHours.Core.Models
{
    public class ExtraHour
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int ExtraHourTypeId { get; set; }
        public int? ApprovedById { get; set; }
        public required string Status { get; set; } // "Pendiente", "Aprobado", "Rechazado"
        public string? Reason { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Propiedades de navegación CORRECTAS:
        public required User User { get; set; }          // Usuario que registra
        public required ExtraHourType ExtraHourType { get; set; } // Tipo de hora extra
        public required User ApprovedBy { get; set; }    // Usuario que aprueba
    }
}