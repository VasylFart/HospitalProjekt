namespace V_Project.Application.Interfaces
{
    public interface IStatusService
    {
        public IEnumerable<StatusDto> GetStatus();

        public StatusDto AddNewStatus(PostStatusDto newPostStatusDto);

        public StatusDto UpdateStatus(PostStatusDto statusDto, int id);

        public void DeleteStatus(int id);
    }
}