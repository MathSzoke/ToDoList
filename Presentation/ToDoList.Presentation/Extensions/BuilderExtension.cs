namespace ToDoList.Presentation.Extensions;

internal static class BuilderExtension
{
    internal static WebApplicationBuilder BuilderArchitectures(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IToDoList, ToDoListService>();

        builder.DbArchitectures();

        builder.Services.AddAutoMapper(typeof(MappingToDoList));

        return builder;
    }
}
