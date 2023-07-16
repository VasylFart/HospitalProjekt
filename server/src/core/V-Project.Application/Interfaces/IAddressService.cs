namespace V_Project.Application;

public interface IAddressService
{
    public IEnumerable<AddressDto> GetAddresses();

    public AddressDto UpdateAddress(PostAddressDto addressDto, Guid id);
}
