namespace V_Project.Application;

public interface IPatientService
{
    public IEnumerable<PatientDto> GetPatients ();
    public PatientDto AddNewPatient(PostPatientDto newPostPatient);
    public PatientDto UpdatePatient(PostPatientDto patientDto, Guid id);
    public void DeletePatient(Guid id);

}
