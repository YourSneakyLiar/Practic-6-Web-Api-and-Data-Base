namespace NewAutoCat.Contracts.User
{
    public class CreateUserRequestcs
    {


        
        public int RoleId { get; set; }
        public string Nickname { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? DateOfRegistration { get; set; }
    }
}
