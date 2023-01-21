namespace V_Project.Application;

public interface ICenterService
{
    public IEnumerable<CenterDto> GetCenters();
    public CenterDto AddNewCenter(PostCenterDto newPostCenterDto);
    public CenterDto UpdateCenter(PostCenterDto centerDto, Guid id);
    public void DeleteCenter(Guid id);
}
