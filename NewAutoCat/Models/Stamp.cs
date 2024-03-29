﻿using System;
using System.Collections.Generic;

namespace NewAutoCat.Models
{
    public partial class Stamp
    {
        public Stamp()
        {
            Cars = new HashSet<Car>();
        }

        public int StampId { get; set; }
        public string StampName { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Car>? Cars { get; set; }
    }
}
