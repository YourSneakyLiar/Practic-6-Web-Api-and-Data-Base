using System;
using System.Collections.Generic;

namespace WebAutoCatalogApi.Models
{
    public partial class Expert
    {
        public Expert()
        {
            Recommendations = new HashSet<Recommendation>();
        }

        public int Rating { get; set; }
        public string ExpertName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public int ExpertId { get; set; }

        public virtual ICollection<Recommendation> Recommendations { get; set; }
    }
}
