namespace NewAutoCat.Contracts.FeedBack
{
    public class CreateFeedBack
    {
        public bool FeedbackLike { get; set; }
      
        public int CommentId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
