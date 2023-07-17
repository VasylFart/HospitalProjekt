namespace V_Project.Application;

public interface IDoctorService
{
    public IEnumerable<DoctorDto> GetDoctors();

    public DoctorDto AddNewDoctor(PostDoctorDto newPostDoctorDto);

    public DoctorDto UpdateDoctor(PostDoctorDto doctorDto, Guid id);

    public void DeleteDoctor(Guid id);
}
