namespace Application.DTOs;

/// <summary>
/// DTO (Data Transfer Object) que representa uma lista de tarefas.
/// </summary>
public class ToDoListDTO
{
    /// <summary>
    /// Obtém ou define o título da lista de tarefas.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Obtém ou define a descrição da lista de tarefas.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Obtém ou define um valor que indica se a lista de tarefas está concluída.
    /// </summary>
    public bool IsCompleted { get; set; }
}
