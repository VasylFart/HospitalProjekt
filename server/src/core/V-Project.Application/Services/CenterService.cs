using V_Project.Domain;

namespace V_Project.Application;

public class CenterService : ICenterService
{
    private readonly IApplicationDbContext dbContext;

    public CenterService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<CenterDto> GetCenters()
    {
        var result = dbContext.Centers.ToList();

        return result.Select(c => new CenterDto
        {
            Id = c.Id,
            Name = c.Name,
        });
    }

    public CenterDto AddNewCenter(PostCenterDto newPostCenterDto)
    {
        var newCenter = new Center()
        {
            Name = newPostCenterDto.Name,
        };

        dbContext.Centers.Add(newCenter);
        dbContext.SaveChangesAsync();

        return new CenterDto
        {
            Id = newCenter.Id,
            Name = newCenter.Name,
        };
    }

    public CenterDto UpdateCenter(PostCenterDto centerDto, int id)
    {
        var center = dbContext.Centers.FirstOrDefault(c => c.Id == id);

        if (center == null)
        {
            throw new ClientException($"Center with Id: {id} doesn`t exist.");
        }

        if (center != null)
        {
            center.Name = centerDto.Name;

            dbContext.Centers.Update(center);
            dbContext.SaveChangesAsync();
        }

        var updatedCenter = dbContext.Centers.FirstOrDefault(c => c.Id == id);

        if (updatedCenter == null)
        {
            throw new Exception();
        }

        return new CenterDto
        {
            Id = updatedCenter.Id,
            Name = updatedCenter.Name
        };
    }

    public void DeleteCenter(int id)
    {
        var center = dbContext.Centers.FirstOrDefault(c => c.Id == id);

        if (center == null)
        {
            throw new ClientException($"Center with Id: {id} doesn`t exist.");
        }

        dbContext.Centers.Remove(center);
        dbContext.SaveChangesAsync();
    }
}
