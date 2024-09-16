//using Microsoft.AspNetCore.Mvc.ApiExplorer;

//using Microsoft.Extensions.Options;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;

//namespace WebApplication1
//{
//    public class AddSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
//    {
//        private readonly IApiVersionDescriptionProvider apiVersionDescriptionProvider;

//        public AddSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
//        {
//            this.apiVersionDescriptionProvider = apiVersionDescriptionProvider;
//        }
//        public void Configure(string? name, SwaggerGenOptions options)
//        {
//            Configure(options);
//        }

//        public void Configure(SwaggerGenOptions options)
//        {
//            foreach(var item in apiVersionDescriptionProvider.ApiVersionDescriptions)
//            {
//                options.SwaggerDoc(item.GroupName, CreateVersionInfo(item));
//            }
//        }

//        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
//        {
//            var info = new OpenApiInfo
//            {
//                Title = "Your versioned Api",
//                Version = description.ApiVersion.ToString()
//            };
//            return info;
//        }
//    }
//}
