using V_Project.Domain;

namespace V_Project.Application;

public class DoctorService : IDoctorService
{
    private readonly IApplicationDbContext dbContext;

    public DoctorService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public DoctorDto AddNewDoctor(PostDoctorDto newPostDoctorDto)
    {
        var newDoctor = new Doctor()
        {
            FullName = newPostDoctorDto.FullName,
        };

        dbContext.Doctors.Add(newDoctor);
        dbContext.SaveChangesAsync();

        return new DoctorDto
        {
            Id = newDoctor.Id,
            FullName = newDoctor.FullName
        };
    }

    public void DeleteDoctor(Guid id)
    {
        var doctor = dbContext.Doctors.FirstOrDefault(c => c.Id == id);

        if (doctor == null)
        {
            throw new ClientException($"Doctor with Id: {id} doesn`t exist.");
        }

        dbContext.Doctors.Remove(doctor);
        dbContext.SaveChangesAsync();
    }

    public IEnumerable<DoctorDto> GetDoctors()
    {
        var result = dbContext.Doctors.ToList();

        return result.Select(c => new DoctorDto
        {
            Id = c.Id,
            FullName = c.FullName,
        });
    }

    public DoctorDto UpdateDoctor(PostDoctorDto doctorDto, Guid id)
    {
        var doctor = dbContext.Doctors.FirstOrDefault(c => c.Id == id);

        if (doctor == null)
        {
            throw new ClientException($"Doctor with Id: {id} doesn`t exist.");
        }

        if (doctor != null)
        {
            doctor.FullName = doctorDto.FullName;

            dbContext.Doctors.Update(doctor);
            dbContext.SaveChangesAsync();
        }

        var updatedDoctor = dbContext.Doctors.FirstOrDefault(c => c.Id == id);

        if (updatedDoctor == null)
        {
            throw new Exception();
        }

        return new DoctorDto
        {
            Id = updatedDoctor.Id,
            FullName = updatedDoctor.FullName
        };
    }
}
