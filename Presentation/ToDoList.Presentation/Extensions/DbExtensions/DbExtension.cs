namespace Presentation.Extensions.DbExtensions;

internal static class DbExtension
{
    internal static WebApplicationBuilder DbArchitectures(this WebApplicationBuilder b)
    {
        b.Services.AddDbContext<ToDoListDbContext>(o => o.UseSqlServer(b.Configuration.GetConnectionString("DefaultConnection")));

        return b;
    }
}
