namespace V_Project.Application;

public interface IPeopleService
{
    public IEnumerable<PeopleDto> GetPeople();
}
