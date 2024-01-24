namespace NewAutoCat.Contracts.News
{
    public class CreateNews
    {
        public DateTime PublicationDate { get; set; }
        public string Heading { get; set; } = null!;
        public string NewsText { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
