using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Application.Repositories;

/// <summary>
/// Interface que define operações relacionadas a listas de tarefas.
/// </summary>
public interface IToDoList
{
    #region GetToDoList

    /// <summary>
    /// Obtém uma lista de tarefas assincronamente.
    /// </summary>
    /// <returns>Task contendo a lista de tarefas.</returns>
    Task<IEnumerable<ToDoListDTO>> GetToDoListAsync();

    /// <summary>
    /// Obtém uma lista de tarefas.
    /// </summary>
    /// <returns>Lista de tarefas.</returns>
    IEnumerable<ToDoListDTO> GetToDoList();

    #endregion

    #region PostToDoList

    /// <summary>
    /// Adiciona uma nova lista de tarefas assincronamente.
    /// </summary>
    /// <param name="tdle">DTO representando a lista de tarefas a ser adicionada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    Task<IActionResult> PostToDoListAsync(ToDoListDTO tdle);

    /// <summary>
    /// Adiciona uma nova lista de tarefas.
    /// </summary>
    /// <param name="tdle">DTO representando a lista de tarefas a ser adicionada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    IActionResult PostToDoList(ToDoListDTO tdle);

    #endregion

    #region PutToDoList

    /// <summary>
    /// Atualiza uma lista de tarefas existente assincronamente.
    /// </summary>
    /// <param name="tdle">DTO representando a lista de tarefas a ser atualizada.</param>
    /// <param name="id">Identificador da lista de tarefas a ser atualizada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    Task<IActionResult> PutToDoListAsync(ToDoListDTO tdle, int? id = null);

    /// <summary>
    /// Atualiza uma lista de tarefas existente.
    /// </summary>
    /// <param name="tdle">DTO representando a lista de tarefas a ser atualizada.</param>
    /// <param name="id">Identificador da lista de tarefas a ser atualizada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    IActionResult PutToDoList(ToDoListDTO tdle, int? id = null);

    #endregion

    #region DeleteToDoList

    /// <summary>
    /// Deleta uma lista de tarefas existente assincronamente.
    /// </summary>
    /// <param name="id">Identificador da lista de tarefas a ser deletada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    Task<IActionResult> DeleteToDoListAsync(int id);

    /// <summary>
    /// Deleta uma lista de tarefas existente.
    /// </summary>
    /// <param name="id">Identificador da lista de tarefas a ser deletada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    IActionResult DeleteToDoList(int id);

    #endregion
}
