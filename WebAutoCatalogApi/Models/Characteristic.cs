using System;
using System.Collections.Generic;

namespace WebAutoCatalogApi.Models
{
    public partial class Characteristic
    {
        public Characteristic()
        {
            Cars = new HashSet<Car>();
        }

        public int IdChar { get; set; }
        public string EngineModel { get; set; } = null!;
        public string EnginePower { get; set; } = null!;
        public string Speed { get; set; } = null!;
        public string CarLength { get; set; } = null!;
        public string CarWidth { get; set; } = null!;
        public string CarHeight { get; set; } = null!;
        public string GroundClearance { get; set; } = null!;
        public string Gearbox { get; set; } = null!;
        public int NumberOfGears { get; set; }
        public string TypeOfDrive { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
