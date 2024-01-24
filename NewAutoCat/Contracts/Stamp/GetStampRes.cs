namespace NewAutoCat.Contracts.Stamp
{
    public class GetStampRes
    {

        public int StampId { get; set; }
        public string StampName { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
