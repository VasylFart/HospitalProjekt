namespace V_Project.Application;

public interface IPersonService
{
    public IEnumerable<PersonDto> GetPeople ();
    public PersonDto AddNewPerson(PostPersonDto newPostPerson);
    public PersonDto UpdatePerson(PostPersonDto personDto, Guid id);
    public void DeletePerson(Guid id);

}
