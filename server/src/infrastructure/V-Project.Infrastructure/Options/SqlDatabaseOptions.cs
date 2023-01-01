namespace V_Project.Infrastructure;

public sealed class SqlDatabaseOptions
{
    public const string Position = "SqlDatabase";

    public string ConnectionString { get; set; } = string.Empty;
}