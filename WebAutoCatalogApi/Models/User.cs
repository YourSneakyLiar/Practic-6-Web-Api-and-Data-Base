using System;
using System.Collections.Generic;

namespace WebAutoCatalogApi.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Reviews = new HashSet<Review>();
        }

        public int IdUser { get; set; }
        public int RoleId { get; set; }
        public string Nickname { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? DateOfRegistration { get; set; }

        public virtual UserRole Role { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
