namespace Application.Services.AutoMapper;

/// <summary>
/// Classe de configuração do AutoMapper para mapeamento entre entidades e DTOs relacionados a listas de tarefas.
/// </summary>
public class MappingToDoList : Profile
{
    /// <summary>
    /// Construtor da classe de configuração do AutoMapper para listas de tarefas.
    /// </summary>
    public MappingToDoList()
    {
        // Configuração do mapeamento da entidade ToDoListEntity para o DTO ToDoListDTO
        this.CreateMap<ToDoListEntity, ToDoListDTO>();

        // Configuração do mapeamento do DTO ToDoListDTO para a entidade ToDoListEntity
        this.CreateMap<ToDoListDTO, ToDoListEntity>();
    }
}
