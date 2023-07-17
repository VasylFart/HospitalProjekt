namespace V_Project.Application;

public interface IContactService
{
    public IEnumerable<ContactDto> GetContact();

    public ContactDto UpdateContact(PostContactDto contactDto, Guid id);
}
