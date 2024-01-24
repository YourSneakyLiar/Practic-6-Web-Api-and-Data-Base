namespace NewAutoCat.Contracts.Expert
{
    public class GetExpert
    {

        public int Rating { get; set; }
        public string ExpertName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public int ExpertId { get; set; }
    }
}
