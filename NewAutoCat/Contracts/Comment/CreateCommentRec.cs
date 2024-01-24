namespace NewAutoCat.Contracts.Comment
{
    public class CreateCommentRec
    {
        public string CommentText { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int IdUser { get; set; }
        public int IdNews { get; set; }

    }
}
