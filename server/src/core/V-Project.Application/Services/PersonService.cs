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

}
