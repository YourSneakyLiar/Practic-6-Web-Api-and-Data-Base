using System;
using System.Collections.Generic;

namespace WebAutoCatalogApi.Models
{
    public partial class Car
    {
        public Car()
        {
            Recommendations = new HashSet<Recommendation>();
            Reviews = new HashSet<Review>();
            TestDrives = new HashSet<TestDrife>();
        }

        public int CarId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int IdChar { get; set; }
        public int StampId { get; set; }
        public string Model { get; set; } = null!;
        public DateTime DateOfRelease { get; set; }
        public int BodyTypeId { get; set; }

        public virtual BodyType BodyType { get; set; } = null!;
        public virtual Characteristic IdCharNavigation { get; set; } = null!;
        public virtual Stamp Stamp { get; set; } = null!;
        public virtual ICollection<Recommendation> Recommendations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<TestDrife> TestDrives { get; set; }
    }
}
