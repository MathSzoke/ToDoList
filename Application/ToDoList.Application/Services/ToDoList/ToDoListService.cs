namespace Application.Services.ToDoList;

/// <summary>
/// Serviço que gerencia operações relacionadas a listas de tarefas.
/// </summary>
/// <remarks>
/// Construtor do serviço ToDoListService.
/// </remarks>
/// <param name="ctx">Contexto do banco de dados para listas de tarefas.</param>
/// <param name="m">Instância do AutoMapper para mapear entre DTOs e entidades.</param>
public class ToDoListService(ToDoListDbContext ctx, IMapper m) : ControllerBase, IToDoList
{
    protected ToDoListDbContext _ctx = ctx;
    protected IMapper _mapper = m;

    #region GetToDoList

    /// <inheritdoc />
    public async Task<IEnumerable<ToDoListDTO>> GetToDoListAsync()
    {
        var entity = await this._ctx.ToDoList.ToListAsync();
        return this._mapper.Map<IEnumerable<ToDoListDTO>>(entity);
    }

    /// <inheritdoc />
    public IEnumerable<ToDoListDTO> GetToDoList()
    {
        var entity = this._ctx.ToDoList.ToList();
        return this._mapper.Map<IEnumerable<ToDoListDTO>> (entity);
    }

    #endregion

    #region PostToDoList

    /// <inheritdoc />
    public async Task<IActionResult> PostToDoListAsync(ToDoListDTO tdlDto)
    {
        if (tdlDto is null) return this.BadRequest("Ocorreu um erro inesperado!");

        var entity = this._mapper.Map<ToDoListEntity>(tdlDto);

        entity.Title = StringExpressions.SplitSentencesWithOneSpace(tdlDto.Title);

        this._ctx.ToDoList.Add(entity);

        await this._ctx.SaveChangesAsync();

        return this.Ok();
    }

    /// <inheritdoc />
    public IActionResult PostToDoList(ToDoListDTO tdlDto)
    {
        if(tdlDto is null) return this.BadRequest("Ocorreu um erro inesperado!");

        var entity = this._mapper.Map<ToDoListEntity>(tdlDto);

        entity.Title = StringExpressions.SplitSentencesWithOneSpace(tdlDto.Title);

        this._ctx.ToDoList.Add(entity);

        this._ctx.SaveChangesAsync();

        return this.Ok();
    }

    #endregion

    #region PutToDoList

    /// <inheritdoc />
    public async Task<IActionResult> PutToDoListAsync(ToDoListDTO tdlDto, int? id = null)
    {
        if (tdlDto is null) return this.BadRequest("Ocorreu um erro inesperado!");

        if (id.HasValue && id.Value != 0)
        {
            var existingList = await this._ctx.ToDoList.FirstOrDefaultAsync(x => x.ID == id);
            if (existingList != null)
            {
                existingList.Title = StringExpressions.SplitSentencesWithOneSpace(tdlDto.Title);
                existingList.Description = tdlDto.Description;
                existingList.IsCompleted = tdlDto.IsCompleted;

                await this._ctx.SaveChangesAsync();

                return this.Ok("Lista alterada com sucesso!");
            }
            else
            {
                return this.NotFound("Lista não encontrada");
            }
        }
        else
        {
            return this.BadRequest("ID inválido.");
        }
    }

    /// <inheritdoc />
    public IActionResult PutToDoList(ToDoListDTO tdlDto, int? id = null)
    {
        if (tdlDto is null) return this.BadRequest("Ocorreu um erro inesperado!");

        if (id.HasValue && id.Value != 0)
        {
            var existingList = this._ctx.ToDoList.FirstOrDefault(x => x.ID == id);
            if (existingList != null)
            {
                existingList.Title = StringExpressions.SplitSentencesWithOneSpace(tdlDto.Title);
                existingList.Description = tdlDto.Description;
                existingList.IsCompleted = tdlDto.IsCompleted;

                this._ctx.SaveChanges();

                return this.Ok("Lista alterada com sucesso!");
            }
            else
            {
                return this.NotFound("Lista não encontrada");
            }
        }
        else
        {
            return this.BadRequest("ID inválido.");
        }
    }

    #endregion

    #region DeleteToDoList

    /// <inheritdoc />
    public async Task<IActionResult> DeleteToDoListAsync(int id)
    {
        var listToDelete = await this._ctx.ToDoList.FirstOrDefaultAsync(x => x.ID == id);

        if (listToDelete != null)
        {
            this._ctx.ToDoList.Remove(listToDelete);
            await this._ctx.SaveChangesAsync();

            return this.NoContent(); // Indica que a operação foi bem-sucedida e não há conteúdo a ser retornado
        }
        else
        {
            return this.NotFound("Lista não encontrada");
        }
    }

    /// <inheritdoc />
    public IActionResult DeleteToDoList(int id)
    {
        var listToDelete = this._ctx.ToDoList.FirstOrDefault(x => x.ID == id);

        if (listToDelete != null)
        {
            this._ctx.ToDoList.Remove(listToDelete);
            this._ctx.SaveChanges();

            return this.NoContent(); // Indica que a operação foi bem-sucedida e não há conteúdo a ser retornado
        }
        else
        {
            return this.NotFound("Lista não encontrada");
        }
    }

    #endregion
}
