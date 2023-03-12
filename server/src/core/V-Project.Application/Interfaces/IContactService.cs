﻿namespace V_Project.Application;

public interface IContactService
{
    public IEnumerable<ContactDto> GetContact();

    public ContactDto AddNewContact(PostContactDto newPostContactDto);

    public ContactDto UpdateContact(PostContactDto contactDto, int id);

    public void DeleteContact(int id);
}
