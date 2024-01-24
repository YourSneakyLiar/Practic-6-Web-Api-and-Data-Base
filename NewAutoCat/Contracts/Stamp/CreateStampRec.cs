namespace NewAutoCat.Contracts.Stamp
{
    public class CreateStampRec
    {
        public string StampName { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
