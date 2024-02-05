namespace Domain.Entities;

/// <summary>
/// Entidade que representa uma lista de tarefas.
/// </summary>
public class ToDoListEntity
{
    /// <summary>
    /// Obtém ou define o identificador único da lista de tarefas.
    /// </summary>
    public int ID { get; set; }

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
