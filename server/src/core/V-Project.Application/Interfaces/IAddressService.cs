namespace V_Project.Application;

public interface IAddressService
{
    public IEnumerable<AddressDto> GetAddresses();

    public AddressDto AddNewAddress(PostAddressDto newPostAddressDto);

    public AddressDto UpdateAddress(PostAddressDto addressDto, Guid id);

    public void DeleteAddress(Guid id);
}
