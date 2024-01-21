using System;
using System.Collections.Generic;

namespace WebAutoCatalogApi.Models
{
    public partial class FeedBack
    {
        public bool FeedbackLike { get; set; }
        public int FeedBackId { get; set; }
        public int CommentId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Comment Comment { get; set; } = null!;
    }
}
