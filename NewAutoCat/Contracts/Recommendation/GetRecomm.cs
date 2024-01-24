namespace NewAutoCat.Contracts.Recommendation
{
    public class GetRecomm
    {
        public int IdRec { get; set; }
        public int ExpertId { get; set; }
        public int CarId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string RecommendationText { get; set; } = null!;
    }
}
