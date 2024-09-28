using Filippov_Georgy_KT_31_21.Services.Implementation;
using Filippov_Georgy_KT_31_21.Services.Interfaces;

namespace Filippov_Georgy_KT_31_21.ServiceExtentions {
    public static class ServiceExtentions {
        public static IServiceCollection AddStudyServices(this IServiceCollection services) {
            services.AddScoped<IDisciplineService, DisciplineService>();

            return services;
        }
    }
}
