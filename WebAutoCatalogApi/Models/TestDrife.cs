using System;
using System.Collections.Generic;

namespace WebAutoCatalogApi.Models
{
    public partial class TestDrife
    {
        public int IdTest { get; set; }
        public int CarId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime TestDate { get; set; }
        public string Comfort { get; set; } = null!;
        public int LenghtDriveRouteKm { get; set; }
        public string EngineOperation { get; set; } = null!;
        public string VisibilityAndManagebility { get; set; } = null!;
        public string SoundInsulationQuality { get; set; } = null!;

        public virtual Car Car { get; set; } = null!;
    }
}
