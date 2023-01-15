namespace V_Project.Application;

public interface IPersonService
{
    public IEnumerable<PersonDto> GetPeople ();
    public void DeletePeople(Guid id);
    public PersonDto UpdatePerson(Guid id, PostPersonDto personDto);
}
