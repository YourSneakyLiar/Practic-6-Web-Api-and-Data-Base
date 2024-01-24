namespace NewAutoCat.Contracts.Characteristic
{
    public class CreateCharRec
    {
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
    }
}
