namespace ASTMA.WebUI.Configurations;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string TaskerCollectionName { get; set; } = null!;
}
