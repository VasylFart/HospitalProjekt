namespace V_Project.Domain;

public class Doctor
{
    public Guid Id { get; set; }

    public string FullName { get; set; }

    public List<Patient> Patients { get; set; }

    public List<Comment> Comments { get; set; }

    public Center Center { get; set; }

    public int CenterId { get; set; }

    public Statistic Statistic { get; set; }

    public int StatisticId { get; set;}
}
