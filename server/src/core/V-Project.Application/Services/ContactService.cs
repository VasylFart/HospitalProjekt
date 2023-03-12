using V_Project.Domain;

namespace V_Project.Application;

public class ContactService : IContactService
{
    private readonly IApplicationDbContext dbContext;

    public ContactService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public ContactDto AddNewContact(PostContactDto newPostContactDto)
    {
        var newContact = new Contact()
        {
            MobilePhone = newPostContactDto.MobilePhone,
            Email = newPostContactDto.Email

        };

        dbContext.Contacts.Add(newContact);
        dbContext.SaveChangesAsync();

        return new ContactDto
        {
            Id = newContact.Id,
            MobilePhone = newContact.MobilePhone,
            Email = newContact.Email
        };
    }

    public void DeleteContact(int id)
    {
        var contact = dbContext.Contacts.FirstOrDefault(c => c.Id == id);

        if (contact == null)
        {
            throw new ClientException($"Contact with Id: {id} doesn`t exist.");
        }

        dbContext.Contacts.Remove(contact);
        dbContext.SaveChangesAsync();
    }

    public IEnumerable<ContactDto> GetContact()
    {
        var result = dbContext.Contacts.ToList();

        return result.Select(c => new ContactDto
        {
            Id = c.Id,
            MobilePhone = c.MobilePhone,
            Email = c.Email
        });
    }

    public ContactDto UpdateContact(PostContactDto contactDto, int id)
    {
        var contact = dbContext.Contacts.FirstOrDefault(c => c.Id == id);

        if (contact == null)
        {
            throw new ClientException($"Contact with Id: {id} doesn`t exist.");
        }

        if (contact != null)
        {
            contact.MobilePhone = contactDto.MobilePhone;
            contact.Email = contactDto.Email;

            dbContext.Contacts.Update(contact);
            dbContext.SaveChangesAsync();
        }

        var updatedContact = dbContext.Contacts.FirstOrDefault(c => c.Id == id);

        if (updatedContact == null)
        {
            throw new Exception();
        }

        return new ContactDto
        {
            Id = updatedContact.Id,
            MobilePhone = updatedContact.MobilePhone,
            Email = updatedContact.Email
        };
    }
}
