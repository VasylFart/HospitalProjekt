using V_Project.Application.Interfaces;
using V_Project.Domain;

namespace V_Project.Application;

public class DepartmentService : IDepartmentDepartment
{
    private readonly IApplicationDbContext dbContext;

    public DepartmentService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public DepartmentDto AddNewDepartment(PostDepartmentDto newPostDepartmentDto)
    {
        var newDepartment = new Department
        {
            Value = newPostDepartmentDto.Value
        };

        dbContext.Depatments.Add(newDepartment);
        dbContext.SaveChangesAsync();

        return new DepartmentDto
        {
            Id = newDepartment.Id,
            Value = newDepartment.Value
        };
    }

    public void DeleteDepartment(Guid id)
    {
        var status = dbContext.Depatments.FirstOrDefault(s => s.Id == id);

        if (status == null)
        {
            throw new ClientException($"Status with Id: {id} doesn`t exist.");
        }

        dbContext.Depatments.Remove(status);
        dbContext.SaveChangesAsync();
    }

    public IEnumerable<DepartmentDto> GetDepartment()
    {
        var result = dbContext.Depatments.ToList();

        return result.Select(s => new DepartmentDto
        {
            Id = s.Id,
            Value = s.Value
        });
    }

    public DepartmentDto UpdateDepartment(PostDepartmentDto departmentDto, Guid id)
    {
        var department = dbContext.Depatments.FirstOrDefault(s => s.Id == id);

        if (department == null)
        {
            throw new ClientException($"Department with Id: {id} doesn`t exist.");
        }

        if(department != null)
        {
            department.Value = departmentDto.Value;

            dbContext.Depatments.Remove(department);
            dbContext.SaveChangesAsync();
        }

        var updatedDepartment = dbContext.Depatments.FirstOrDefault(s => s.Id == id);

        if (updatedDepartment == null)
        {
            throw new Exception();
        }

        return new DepartmentDto
        {
            Id = updatedDepartment.Id,
            Value = updatedDepartment.Value
        };
    }
}
