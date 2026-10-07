using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace wirachain_backend.Shared.Extensions.Swagger;

public class TimeSpanSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(TimeSpan) || context.Type == typeof(TimeSpan?))
        {
            schema.Type = "string";
            schema.Format = "time-span";
            schema.Example = new OpenApiString("14:30:00");
            schema.Description = "Format: HH:mm:ss (ej. 14:30:00)";
        }
    }
}