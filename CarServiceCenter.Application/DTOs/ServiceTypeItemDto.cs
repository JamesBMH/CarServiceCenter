namespace CarServiceCenter.Application.DTOs
{
    public class ServiceTypeItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsLocked { get; set; }
        public int SortOrder { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; } = string.Empty;
    }
}
