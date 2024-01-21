using System;
using System.Collections.Generic;

namespace WebAutoCatalogApi.Models
{
    public partial class BodyType
    {
        public BodyType()
        {
            Cars = new HashSet<Car>();
        }

        public int BodyTypeId { get; set; }
        public string BodyTypeName { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
