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
            Name = x.Name,
            DateOfBirth = x.DateOfBirth,
            Pesel = x.Pesel,
            City = x.City,
            Contact = x.Contact,
            MobilePhone = x.MobilePhone
        });
    }

    public PatientDto AddNewPatient(PostPatientDto newPostPatient)
    {
        var newPatient = new Patient()
        {
            Name = newPostPatient.Name,
            DateOfBirth = newPostPatient.DateOfBirth,
            Pesel = newPostPatient.Pesel,
            City = newPostPatient.City,
            Contact = newPostPatient.Contact,
            MobilePhone = newPostPatient.MobilePhone
        };

        dbContext.Patients.Add(newPatient);
        dbContext.SaveChangesAsync();

        return new PatientDto
        {
            Id = newPatient.Id,
            Name = newPatient.Name,
            DateOfBirth = newPatient.DateOfBirth,
            Pesel = newPatient.Pesel,
            City = newPatient.City,
            Contact = newPatient.Contact,
            MobilePhone = newPatient.MobilePhone
        };
    }

    public PatientDto UpdatePatient(PostPatientDto postPatientDto, Guid id)
    {
        var patient = dbContext.Patients.FirstOrDefault(p => p.Id == id);

        if (patient != null)
        {
            patient.Name = postPatientDto.Name;
            patient.DateOfBirth = postPatientDto.DateOfBirth;
            patient.Pesel = postPatientDto.Pesel;
            patient.City = postPatientDto.City;
            patient.Contact = postPatientDto.Contact;
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
            DateOfBirth = updatedPatient.DateOfBirth,
            Pesel = updatedPatient.Pesel,
            City = updatedPatient.City,
            Contact = updatedPatient.Contact,
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
