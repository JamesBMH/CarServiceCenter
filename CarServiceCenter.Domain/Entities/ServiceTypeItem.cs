namespace CarServiceCenter.Domain.Entities
{
    public class ServiceTypeItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsLocked { get; set; }
        public int SortOrder { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; } = null!;
    }
}
