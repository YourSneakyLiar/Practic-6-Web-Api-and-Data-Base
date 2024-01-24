namespace NewAutoCat.Contracts.Review
{
    public class CreateRev
    {
        
        public int IdUser { get; set; }
        public int CarId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string ReviewText { get; set; } = null!;
        public DateTime DateOfPublication { get; set; }
    }
}
