namespace ExtraHours.Core.Models {

    public class ExtraHourType
    {
        public int Id { get; set;}
        public required string Name { get; set; }
        public decimal RateMultiplier { get; set; } = 1.0m;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }


    }

}