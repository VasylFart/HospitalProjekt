using Microsoft.Extensions.DependencyInjection;

namespace V_Project.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPatientService, PatientService>();

        services.AddScoped<ICenterService, CenterService>();

        services.AddScoped<IAddressService, AddressService>();

        services.AddScoped<ICommentService, CommentService>();

        services.AddScoped<IDoctorService, DoctorService>();

        services.AddScoped<IRoomService, RoomService>();

        services.AddScoped<IContactService, ContactService>();

        return services;
    }
}