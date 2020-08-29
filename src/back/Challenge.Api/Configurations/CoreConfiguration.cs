using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace src.back.Challenge.Api.Configurations
{
    public static class CoreConfiguration
    {
        public static void AddCoreConfiguration(this IServiceCollection services)
            => services.AddResponseCompression()
                .AddControllers()
                .ConfigureApiBehaviorOptions(options => options.SuppressMapClientErrors = true)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Formatting = Formatting.None;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
    }
}