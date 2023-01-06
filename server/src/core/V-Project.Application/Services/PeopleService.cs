namespace V_Project.Application;

public class PeopleService : IPeopleService
{
    private readonly IApplicationDbContext dbContext;

    public PeopleService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<PeopleDto> GetPeople()
    {
        var result = dbContext.People
            .ToList();

        return result.Select(x => new PeopleDto
        {
            Id = x.Id,
            Name = x.Name,
            Age = x.Age,
            Country = x.Country
        });
    }

}
