﻿using V_Project.Domain;

namespace V_Project.Application;

public class PersonService : IPersonService
{
    private readonly IApplicationDbContext dbContext;

    public PersonService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<PersonDto> GetPeople()
    {
        var result = dbContext.People
            .ToList();

        return result.Select(x => new PersonDto
        {
            Id = x.Id,
            Name = x.Name,
            Age = x.Age,
            Country = x.Country
        });
    }

    public PersonDto AddNewPerson(PostPersonDto newPostPerson)
    {
        var newPerson = new Person()
        {
            Name = newPostPerson.Name,
            Age = newPostPerson.Age,
            Country = newPostPerson.Country
        };

        dbContext.People.Add(newPerson);
        dbContext.SaveChangesAsync();

        return new PersonDto
        {
            Id = newPerson.Id,
            Name = newPerson.Name,
            Age = newPerson.Age,
            Country = newPerson.Country
        };
    }

    public PersonDto UpdatePerson(PostPersonDto postPersonDto, Guid id)
    {
        var person = dbContext.People.FirstOrDefault(p => p.Id == id);

        if (person != null)
        {

            person.Name = postPersonDto.Name;
            person.Age = postPersonDto.Age;
            person.Country = postPersonDto.Country;

            dbContext.People.Update(person);
            dbContext.SaveChangesAsync();
        }

        var updatedPerson = dbContext.People.FirstOrDefault(p => p.Id == id);

        if (updatedPerson == null)
        {
            throw new Exception();
        }

        return new PersonDto
        {
            Id = updatedPerson.Id,
            Name = updatedPerson.Name,
            Age = updatedPerson.Age,
            Country = updatedPerson.Country
        };
    }

    public void DeletePerson(Guid id)
    {
        var person = dbContext.People.FirstOrDefault(p => p.Id == id);

        if (person == null)
        {
            throw new ClientException($"Person with Id: {id} doesn't exist.");
        }

        dbContext.People.Remove(person);
        dbContext.SaveChangesAsync();
    }
}
