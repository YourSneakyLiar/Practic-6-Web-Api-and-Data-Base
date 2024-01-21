using System;
using System.Collections.Generic;

namespace WebAutoCatalogApi.Models
{
    public partial class Comment
    {
        public Comment()
        {
            FeedBacks = new HashSet<FeedBack>();
        }

        public int CommentId { get; set; }
        public string CommentText { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int IdUser { get; set; }
        public int IdNews { get; set; }

        public virtual News IdNewsNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<FeedBack> FeedBacks { get; set; }
    }
}
