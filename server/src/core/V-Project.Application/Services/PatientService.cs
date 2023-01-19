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
            DateOfBirth = x.DateOfBirth,
            Pesel = x.Pesel,
            Citi = x.Citi,
            Kontakt = x.Kontakt,
            MobilePhone = x.MobilePhone
        });
    }

    public PatientDto AddNewPatient(PostPatientDto newPostPatient)
    {
        var newPatient = new Patient()
        {
            Name = newPostPatient.Name,
            Age = newPostPatient.Age,
            DateOfBirth= newPostPatient.DateOfBirth,
            Pesel= newPostPatient.Pesel,
            Citi = newPostPatient.Citi,
            Kontakt = newPostPatient.Kontakt,
            MobilePhone= newPostPatient.MobilePhone
        };

        dbContext.Patients.Add(newPatient);
        dbContext.SaveChangesAsync();

        return new PatientDto
        {
            Id = newPatient.Id,
            Name = newPatient.Name,
            Age = newPatient.Age,
            DateOfBirth = newPatient.DateOfBirth,
            Pesel = newPatient.Pesel,
            Citi = newPatient.Citi,
            Kontakt = newPatient.Kontakt,
            MobilePhone = newPatient.MobilePhone
        };
    }

    public PatientDto UpdatePatient(PostPatientDto postPatientDto, Guid id)
    {
        var patient = dbContext.Patients.FirstOrDefault(p => p.Id == id);

        if (patient != null)
        {

            patient.Name = postPatientDto.Name;
            patient.Age = postPatientDto.Age;
            patient.DateOfBirth = postPatientDto.DateOfBirth;
            patient.Pesel = postPatientDto.Pesel;
            patient.Citi = postPatientDto.Citi;
            patient.Kontakt = postPatientDto.Kontakt;
            patient.MobilePhone = postPatientDto.MobilePhone;

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
            DateOfBirth = updatedPatient.DateOfBirth,
            Pesel = updatedPatient.Pesel,
            Citi = updatedPatient.Citi,
            Kontakt = updatedPatient.Kontakt,
            MobilePhone = updatedPatient.MobilePhone
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
