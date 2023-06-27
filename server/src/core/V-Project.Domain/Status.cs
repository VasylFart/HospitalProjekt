namespace V_Project.Domain;

public class Status
{
    public int Id { get; set; }

    public string Value { get; set; }

    public Patient Patient { get; set; }

    public Guid PatientId { get; set; }

    public Statistic Statistic { get; set; }

    public int StatisticId { get; set; }
}
