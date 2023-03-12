using V_Project.Domain;

namespace V_Project.Application;

public class AddressService : IAddressService
{
    private readonly IApplicationDbContext dbContext;

    public AddressService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public AddressDto AddNewAddress(PostAddressDto newPostAddressDto)
    {
        var newAddress = new Address()
        {
            Country = newPostAddressDto.Country,
            City = newPostAddressDto.City,
            Street = newPostAddressDto.Street,
            NumberHome = newPostAddressDto.NumberHome


        };

        dbContext.Addresses.Add(newAddress);
        dbContext.SaveChangesAsync();

        return new AddressDto
        {
            Id = newAddress.Id,
            Country = newAddress.Country,
            City = newAddress.City,
            Street = newAddress.Street,
            NumberHome = newAddress.NumberHome
        };
    }

    public void DeleteAddress(Guid id)
    {
        var address = dbContext.Addresses.FirstOrDefault(c => c.Id == id);

        if (address == null)
        {
            throw new ClientException($"Address with Id: {id} doesn`t exist.");
        }

        dbContext.Addresses.Remove(address);
        dbContext.SaveChangesAsync();
    }

    public IEnumerable<AddressDto> GetAddresses()
    {
        var result = dbContext.Addresses.ToList();

        return result.Select(c => new AddressDto
        {
            Id = c.Id,
            Country = c.Country,
            City = c.City,
            Street = c.Street,
            NumberHome = c.NumberHome
        });
    }

    public AddressDto UpdateAddress(PostAddressDto addressDto, Guid id)
    {
        var address = dbContext.Addresses.FirstOrDefault(c => c.Id == id);

        if (address == null)
        {
            throw new ClientException($"Address with Id: {id} doesn`t exist.");
        }

        if (address != null)
        {
            address.Country = addressDto.Country;
            address.City = addressDto.City;
            address.Street = addressDto.Street;
            address.NumberHome = addressDto.NumberHome;

            dbContext.Addresses.Update(address);
            dbContext.SaveChangesAsync();
        }

        var updatedAddress = dbContext.Addresses.FirstOrDefault(c => c.Id == id);

        if (updatedAddress == null)
        {
            throw new Exception();
        }

        return new AddressDto
        {
            Id = updatedAddress.Id,
            Country = updatedAddress.Country,
            City = updatedAddress.City,
            Street = updatedAddress.Street,
            NumberHome = updatedAddress.NumberHome
        };
    }
}
