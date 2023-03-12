using V_Project.Domain;

namespace V_Project.Application;

public class PatientService : IPatientService
{
    private readonly IApplicationDbContext dbContext;

    public PatientService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<PatientDto> GetPatients()
    {
        var result = dbContext.Patients.ToList();

        return result.Select(x => new PatientDto
        {
            Id = x.Id,
            FullName = x.FullName,
            DateOfBirth = x.DateOfBirth,
            Pesel = x.Pesel,
        });
    }

    public PatientDto AddNewPatient(PostPatientDto newPostPatient)
    {
        var newPatient = new Patient()
        {
            FullName = newPostPatient.FullName,
            DateOfBirth = newPostPatient.DateOfBirth,
            Pesel = newPostPatient.Pesel,
        };

        dbContext.Patients.Add(newPatient);
        dbContext.SaveChangesAsync();

        return new PatientDto
        {
            Id = newPatient.Id,
            FullName = newPatient.FullName,
            DateOfBirth = newPatient.DateOfBirth,
            Pesel = newPatient.Pesel,
        };
    }

    public PatientDto UpdatePatient(PostPatientDto postPatientDto, Guid id)
    {
        var patient = dbContext.Patients.FirstOrDefault(p => p.Id == id);

        if (patient != null)
        {
            patient.FullName = postPatientDto.FullName;
            patient.DateOfBirth = postPatientDto.DateOfBirth;
            patient.Pesel = postPatientDto.Pesel;

            dbContext.Patients.Update(patient);
            dbContext.SaveChangesAsync();
        }

        var updatedPatient = dbContext.Patients.FirstOrDefault(p => p.Id == id);

        if (updatedPatient == null)
        {
            throw new Exception();
        }

        return new PatientDto
        {
            Id = updatedPatient.Id,
            FullName = updatedPatient.FullName,
            DateOfBirth = updatedPatient.DateOfBirth,
            Pesel = updatedPatient.Pesel,
        };
    }

    public void DeletePatient(Guid id)
    {
        var patient = dbContext.Patients.FirstOrDefault(p => p.Id == id);

        if (patient == null)
        {
            throw new ClientException($"Patient with Id: {id} doesn't exist.");
        }

        dbContext.Patients.Remove(patient);
        dbContext.SaveChangesAsync();
    }
}
