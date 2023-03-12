namespace V_Project.Domain
{
    public class Center
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Patient> Patients { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
