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

    public void DeletePeople(Guid id)
    {
        var person = dbContext.People.FirstOrDefault(p => p.Id == id);

        if (person == null)
        {
            throw new ClientException($"Person with Id: {id} doesn't exist.");
        }
        
        dbContext.People.Remove(person);
        dbContext.SaveChangesAsync();
    }

    public PersonDto UpdatePeople(Guid id, PersonDto personDto)
    {
        var person = dbContext.People.FirstOrDefault(p => p.Id == id);

        if (person != null)
        {
            person.Name = personDto.Name;
            person.Age = personDto.Age;
            person.Country = personDto.Country;

            dbContext.People.Update(person);
            dbContext.SaveChangesAsync();
        }

        return personDto;
    }
}
