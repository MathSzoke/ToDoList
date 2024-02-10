namespace ToDoList.Presentation.Extensions;

internal static class AppExtension
{
    internal static WebApplication AppArchitectures(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoListAPI"));
        }

        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
