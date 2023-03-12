namespace V_Project.Application;

public interface IRoomService
{
    public IEnumerable<RoomDto> GetRoom();

    public RoomDto AddNewRoom(PostRoomDto newPostRoomDto);

    public RoomDto UpdateRoom(PostRoomDto roomDto, int id);

    public void DeleteRoom(int id);
}
