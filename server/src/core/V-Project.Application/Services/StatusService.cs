using V_Project.Application.Interfaces;
using V_Project.Domain;

namespace V_Project.Application;

public class StatusService : IStatusService
{
    private readonly IApplicationDbContext dbContext;

    public StatusService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public StatusDto AddNewStatus(PostStatusDto newPostStatusDto)
    {
        var newStatus = new Status()
        {
            Value = newPostStatusDto.Value
        };

        dbContext.Statuses.Add(newStatus);
        dbContext.SaveChangesAsync();

        return new StatusDto
        {
            Id = newStatus.Id,
            Value = newStatus.Value
        };
    }

    public void DeleteStatus(int id)
    {
        var status = dbContext.Statuses.FirstOrDefault(s => s.Id == id);

        if (status == null)
        {
            throw new ClientException($"Status with Id: {id} doesn`t exist.");
        }

        dbContext.Statuses.Remove(status);
        dbContext.SaveChangesAsync();
    }

    public IEnumerable<StatusDto> GetStatus()
    {
        var result = dbContext.Statuses.ToList();

        return result.Select(s => new StatusDto
        {
            Id = s.Id,
            Value = s.Value
        });
    }

    public StatusDto UpdateStatus(PostStatusDto statusDto, int id)
    {
        var status = dbContext.Statuses.FirstOrDefault(s => s.Id == id);

        if (status == null)
        {
            throw new ClientException($"Status with Id: {id} doesn`t exist.");
        }

        if(status != null)
        {
            status.Value = statusDto.Value;

            dbContext.Statuses.Remove(status);
            dbContext.SaveChangesAsync();
        }

        var updatedStatus = dbContext.Statuses.FirstOrDefault(s => s.Id == id);

        if (updatedStatus == null)
        {
            throw new Exception();
        }

        return new StatusDto
        {
            Id = updatedStatus.Id,
            Value = updatedStatus.Value
        };
    }
}
