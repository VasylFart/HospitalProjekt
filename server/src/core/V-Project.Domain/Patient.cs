namespace V_Project.Domain
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Country { get; set; }
    }
}
