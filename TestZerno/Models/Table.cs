namespace TestZerno.Models
{
    public class Table
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; set; }
        public int BranchId { get; set; }
        public int CropYear { get; set; }
        public int CounterpartyId { get; set; }
        public string CounterpartyName { get; set; }
        public int ContactId { get; set; }
        public string Product { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string Process { get; set; }
        public float? Wetness { get; set; }
        public float? Garbage { get; set; }
        public string? Infection { get; set; }
    }
}
