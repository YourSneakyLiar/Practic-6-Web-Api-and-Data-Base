namespace NewAutoCat.Contracts.News
{
    public class GetNews
    {
        public int IdNews { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Heading { get; set; } = null!;
        public string NewsText { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
