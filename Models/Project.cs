namespace Portfolio.Models
{
    public class Project
    {
        public string Title { get; set; } = string.Empty;
        public string SystemName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Technologies { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? LiveLink { get; set; }
    }
}
