using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Application.Repositories;

namespace ToDoList.Presentation.Controllers;

/// <summary>
/// Controller responsável por gerenciar operações relacionadas a listas de tarefas.
/// </summary>
/// <remarks>
/// Construtor da classe ToDoListController.
/// </remarks>
/// <param name="t">Serviço de gerenciamento de listas de tarefas.</param>
[ApiController]
[Route("api/tasks/")]
public class ToDoListController(IToDoList t) : ControllerBase
{

    #region GetToDoList

    /// <summary>
    /// Obtém todas as listas de tarefas assincronamente.
    /// </summary>
    /// <returns>Lista de tarefas encapsulada em um objeto Task.</returns>
    [HttpGet(nameof(GetAllToDoListAsync))]
    public async Task<IEnumerable<ToDoListDTO>> GetAllToDoListAsync() => await t.GetToDoListAsync();

    /// <summary>
    /// Obtém todas as listas de tarefas.
    /// </summary>
    /// <returns>Lista de tarefas.</returns>
    [HttpGet(nameof(GetAllToDoList))]
    public IEnumerable<ToDoListDTO> GetAllToDoList() => t.GetToDoList();

    #endregion

    #region PostToDoList

    /// <summary>
    /// Adiciona uma nova lista de tarefas assincronamente.
    /// </summary>
    /// <param name="tdle">DTO representando a lista de tarefas a ser adicionada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    [HttpPost(nameof(PostToDoListAsync))]
    public async Task<IActionResult> PostToDoListAsync([FromBody] ToDoListDTO tdle) => await t.PostToDoListAsync(tdle);

    /// <summary>
    /// Adiciona uma nova lista de tarefas.
    /// </summary>
    /// <param name="tdle">DTO representando a lista de tarefas a ser adicionada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    [HttpPost(nameof(PostToDoList))]
    public IActionResult PostToDoList([FromBody] ToDoListDTO tdle) => t.PostToDoList(tdle);

    #endregion

    #region PutToDoList

    /// <summary>
    /// Atualiza uma lista de tarefas existente assincronamente.
    /// </summary>
    /// <param name="tdle">DTO representando a lista de tarefas a ser atualizada.</param>
    /// <param name="id">Identificador da lista de tarefas a ser atualizada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    [HttpPut(nameof(PutToDoListAsync) + "/{id?}")]
    public async Task<IActionResult> PutToDoListAsync(ToDoListDTO tdle, int? id = null) => await t.PutToDoListAsync(tdle, id);

    /// <summary>
    /// Atualiza uma lista de tarefas existente.
    /// </summary>
    /// <param name="tdle">DTO representando a lista de tarefas a ser atualizada.</param>
    /// <param name="id">Identificador da lista de tarefas a ser atualizada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    [HttpPut(nameof(PutToDoList) + "/{id?}")]
    public IActionResult PutToDoList(ToDoListDTO tdle, int? id = null) => t.PutToDoList(tdle, id);

    #endregion

    #region DeleteToDoList

    /// <summary>
    /// Deleta uma lista de tarefas existente assincronamente.
    /// </summary>
    /// <param name="id">Identificador da lista de tarefas a ser deletada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    [HttpDelete(nameof(DeleteToDoListAsync) + "/{id?}")]
    public async Task<IActionResult> DeleteToDoListAsync(int id) => await t.DeleteToDoListAsync(id);

    /// <summary>
    /// Deleta uma lista de tarefas existente.
    /// </summary>
    /// <param name="id">Identificador da lista de tarefas a ser deletada.</param>
    /// <returns>ActionResult indicando o resultado da operação.</returns>
    [HttpDelete(nameof(DeleteToDoList) + "/{id?}")]
    public IActionResult DeleteToDoList(int id) => t.DeleteToDoList(id);

    #endregion
}
