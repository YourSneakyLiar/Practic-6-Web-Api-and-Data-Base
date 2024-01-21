using System;
using System.Collections.Generic;

namespace WebAutoCatalogApi.Models
{
    public partial class News
    {
        public News()
        {
            Comments = new HashSet<Comment>();
        }

        public int IdNews { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Heading { get; set; } = null!;
        public string NewsText { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
