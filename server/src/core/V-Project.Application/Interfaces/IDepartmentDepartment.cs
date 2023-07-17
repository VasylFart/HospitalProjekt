namespace V_Project.Application.Interfaces
{
    public interface IDepartmentDepartment
    {
        public IEnumerable<DepartmentDto> GetDepartment();

        public DepartmentDto AddNewDepartment(PostDepartmentDto newPostDepartmentDto);

        public DepartmentDto UpdateDepartment(PostDepartmentDto departmentDto, Guid id);

        public void DeleteDepartment(Guid id);
    }
}