using V_Project.Domain;

namespace V_Project.Application;

public class RoomService : IRoomService
{
    private readonly IApplicationDbContext dbContext;

    public RoomService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public RoomDto AddNewRoom(PostRoomDto newPostRoomDto)
    {
        var newRoom = new Room
        {
            Number = newPostRoomDto.Number,
            Capacity = newPostRoomDto.Capacity,
            DepartmentId = Guid.Parse(newPostRoomDto.DepartmentId)
        };

        dbContext.Rooms.Add(newRoom);
        dbContext.SaveChangesAsync();

        return new RoomDto
        {
            Id = newRoom.Id,
            Number = newRoom.Number,
            FreeSlots = newRoom.FreeSlots
        };
    }

    public void DeleteRoom(Guid id)
    {
        var room = dbContext.Rooms.FirstOrDefault(c => c.Id == id);

        if (room == null)
        {
            throw new ClientException($"Room with Id: {id} doesn`t exist.");
        }

        dbContext.Rooms.Remove(room);
        dbContext.SaveChangesAsync();
    }

    public IEnumerable<RoomDto> GetRoom()
    {
        var result = dbContext.Rooms.ToList();

        return result.Select(c => new RoomDto
        {
            Id = c.Id,
            Number = c.Number
        });
    }

    public RoomDto UpdateRoom(PostRoomDto roomDto, Guid id)
    {
        var room = dbContext.Rooms.FirstOrDefault(c => c.Id == id);

        if (room == null)
        {
            throw new ClientException($"Room with Id: {id} doesn`t exist.");
        }

        if (room != null)
        {
            room.Number = roomDto.Number;

            dbContext.Rooms.Update(room);
            dbContext.SaveChangesAsync();
        }

        var updatedRoom = dbContext.Rooms.FirstOrDefault(c => c.Id == id);

        if (updatedRoom == null)
        {
            throw new Exception();
        }

        return new RoomDto
        {
            Id = updatedRoom.Id,
            Number = updatedRoom.Number
        };
    }
}
