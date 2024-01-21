using System;
using System.Collections.Generic;

namespace WebAutoCatalogApi.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int IdUser { get; set; }
        public int CarId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string ReviewText { get; set; } = null!;
        public DateTime DateOfPublication { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
