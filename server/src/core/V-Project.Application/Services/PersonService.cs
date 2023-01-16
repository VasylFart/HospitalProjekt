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
        var result = dbContext.Patients
            .ToList();

        return result.Select(x => new PatientDto
        {
            Id = x.Id,
            Name = x.Name,
            Age = x.Age,
            Country = x.Country
        });
    }

    public PatientDto AddNewPatient(PostPatientDto newPostPatient)
    {
        var newPatient = new Patient()
        {
            Name = newPostPatient.Name,
            Age = newPostPatient.Age,
            Country = newPostPatient.Country
        };

        dbContext.Patients.Add(newPatient);
        dbContext.SaveChangesAsync();

        return new PatientDto
        {
            Id = newPatient.Id,
            Name = newPatient.Name,
            Age = newPatient.Age,
            Country = newPatient.Country
        };
    }

    public PatientDto UpdatePatient(PostPatientDto postPatientDto, Guid id)
    {
        var patient = dbContext.Patients.FirstOrDefault(p => p.Id == id);

        if (patient != null)
        {

            patient.Name = postPatientDto.Name;
            patient.Age = postPatientDto.Age;
            patient.Country = postPatientDto.Country;

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
            Name = updatedPatient.Name,
            Age = updatedPatient.Age,
            Country = updatedPatient.Country
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
