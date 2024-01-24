namespace NewAutoCat.Contracts.Role
{
    public class GetRoleResponse
    {
        public int RoleId { get; set; }
        public string NameRole { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
