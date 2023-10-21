namespace NBL.BPA.Domain.Entities
{
    public class Logger : BaseEntity
    {
        public string LogFileName { get; set; } = string.Empty;
        public string LogFilePath { get; set; } = string.Empty;
        public DateTime? ProcessEndDate { get; set; }
        public string FileStatus { get; set; }

    }
    public enum FileStatus
    {
        Received,
        Processed

    }
}
