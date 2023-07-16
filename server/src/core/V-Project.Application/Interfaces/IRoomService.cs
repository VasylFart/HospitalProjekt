namespace V_Project.Application;

public interface IRoomService
{
    public IEnumerable<RoomDto> GetRoom();

    public RoomDto AddNewRoom(PostRoomDto newPostRoomDto);

    public RoomDto UpdateRoom(PostRoomDto roomDto, Guid id);

    public void DeleteRoom(Guid id);
}
