namespace NewAutoCat.Contracts.Car
{
    public class GetCarRes
    {

        public int CarId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int IdChar { get; set; }
        public int StampId { get; set; }
        public string Model { get; set; } = null!;
        public DateTime DateOfRelease { get; set; }
        public int BodyTypeId { get; set; }
    }
}
