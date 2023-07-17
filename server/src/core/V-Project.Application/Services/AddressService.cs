using V_Project.Domain;

namespace V_Project.Application;

public class AddressService : IAddressService
{
    private readonly IApplicationDbContext dbContext;

    public AddressService(IApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
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
            HomeNumber = c.HomeNumber
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
            address.HomeNumber = addressDto.HomeNumber;

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
            HomeNumber = updatedAddress.HomeNumber
        };
    }
}
