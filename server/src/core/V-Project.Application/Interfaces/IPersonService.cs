namespace V_Project.Application;

public interface IPersonService
{
    public IEnumerable<PersonDto> GetPeople ();
    public void DeletePerson(Guid id);
    public PersonDto UpdatePerson(Guid id, PostPersonDto personDto);
}
