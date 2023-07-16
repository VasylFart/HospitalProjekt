using Microsoft.Extensions.DependencyInjection;
using V_Project.Application.Interfaces;

namespace V_Project.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication (this IServiceCollection services)
    {
        services.AddScoped<IPatientService, PatientService>();

        services.AddScoped<IAddressService, AddressService>();

        services.AddScoped<ICommentService, CommentService>();

        services.AddScoped<IDoctorService, DoctorService>();

        services.AddScoped<IRoomService, RoomService>();

        services.AddScoped<IContactService, ContactService>();

        services.AddScoped<IDepartmentDepartment, DepartmentService>();

        return services;
    }
}