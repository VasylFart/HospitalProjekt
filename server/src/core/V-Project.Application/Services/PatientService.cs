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
        var room = dbContext.Rooms.FirstOrDefault(r => r.Id == Guid.Parse(newPostPatient.RoomId));

        if (room != null && room.FreeSlots > 0)
        {
            var newPatient = new Patient
            {
                FullName = newPostPatient.FullName,
                DateOfBirth = newPostPatient.DateOfBirth,
                Pesel = newPostPatient.Pesel,

                Address = new Address
                {
                    Country = newPostPatient.Address.Country,
                    City = newPostPatient.Address.City,
                    Street = newPostPatient.Address.Street,
                    HomeNumber = newPostPatient.Address.HomeNumber
                },

                Contact = new Contact
                {
                    MobilePhone = newPostPatient.Contact.MobilePhone,
                    Email = newPostPatient.Contact.Email
                },

                DoctorId = Guid.Parse(newPostPatient.DoctorId),

                DepartmentId = Guid.Parse(newPostPatient.DepartmentId),

                RoomId = Guid.Parse(newPostPatient.RoomId),

                Comment = new Comment
                {
                    Message = newPostPatient.Comment.Message
                },
            };

            room.OccupiedSlots++;

            dbContext.Patients.Add(newPatient);
            dbContext.SaveChangesAsync();

            return new PatientDto
            {
                Id = newPatient.Id,
                FullName = newPatient.FullName,
                DateOfBirth = newPatient.DateOfBirth,
                Pesel = newPatient.Pesel
            };
        }

        else
        {
            throw new ClientException("Cannot add a patient. The room is full.");
        }
            
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
