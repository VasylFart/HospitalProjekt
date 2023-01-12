namespace V_Project.Application;

public interface IPersonService
{
    public IEnumerable<PersonDto> GetPeople ();
}
