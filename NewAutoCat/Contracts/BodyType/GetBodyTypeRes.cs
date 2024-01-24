namespace NewAutoCat.Contracts.BodyType
{
    public class GetBodyTypeRes
    {

        public int BodyTypeId { get; set; }
        public string BodyTypeName { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
