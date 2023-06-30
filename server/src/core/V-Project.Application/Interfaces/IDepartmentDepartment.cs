namespace V_Project.Application.Interfaces
{
    public interface IDepartmentDepartment
    {
        public IEnumerable<DepartmentDto> GetDepartment();

        public DepartmentDto AddNewDepartment(PostDepartmentDto newPostDepartmentDto);

        public DepartmentDto UpdateDepartment(PostDepartmentDto departmentDto, int id);

        public void DeleteDepartment(int id);
    }
}