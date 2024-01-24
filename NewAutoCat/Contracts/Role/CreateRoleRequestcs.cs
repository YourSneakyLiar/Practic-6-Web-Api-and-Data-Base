namespace NewAutoCat.Contracts.Role
{
    public class CreateRoleRequestcs
    {

       
        public string NameRole { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
