using System;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Exceptions;
using API.Models;
using API.Models.InputModels;
using API.Services;
using API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[ApiController]
[Route("/tarefas")]
public class TarefasController : ControllerBase
{
    private readonly ITarefasService _tarefasServices;
    public TarefasController(ITarefasService tarefasServices)
    {
        _tarefasServices = tarefasServices;
    }
    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var tarefas =await _tarefasServices.SelecioneTodas();
            return Ok(tarefas);

        }
        catch (TarefasException te)
        {
            return BadRequest(new { mensagem = te.Message });
        }
        catch (Exception e)
        {

            return BadRequest(new { mensagem = e.Message });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var tarefas = await _tarefasServices.SelecionePorId(id);

            return Ok(tarefas);
        }
        catch (TarefasException te)
        {
            return NotFound(new { mensagem = te.Message });
        }
        catch (Exception ex)
        {

            return BadRequest(new { mensagem = ex.Message });
        }
    }

    [HttpPost("")]
    public IActionResult Post(TarefaInputModel inputModel)
    {
        try
        {
            _tarefasServices.Inserir(new TarefaModel(inputModel.Titulo,
                                                     inputModel.Descricao,
                                                     inputModel.Completada));

            return NoContent();
        }
        catch (TarefasException te)
        {
            return BadRequest(new { mensagem = te.Message });
        }
        catch (Exception ex)
        {

            return BadRequest(new { mensagem = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(TarefaInputModel inputModel, int id)
    {
        try
        {
            var tarefas = await _tarefasServices.Atualizar(id,
                                                     new TarefaModel(inputModel.Titulo,
                                                                     inputModel.Descricao,
                                                                     inputModel.Completada));

            return Ok(tarefas);
        }
        catch (TarefasException te)
        {
            return NotFound(new { mensagem = te.Message });
        }
        catch (Exception ex)
        {

            return BadRequest(new { mensagem = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var tarefa = await _tarefasServices.Remover(id);

            return Ok(new { messagem = $"a tarefa {tarefa.Title} foi excluida com sucesso " });
        }
        catch (TarefasException te)
        {
            return NotFound(new { mensagem = te.Message });
        }
        catch (Exception ex)
        {

            return BadRequest(new { mensagem = ex.Message });
        }

    }

    [HttpPatch("concluir/{id:int}")]
    public async Task<IActionResult> CompleteTask(int id)
    {
        try
        {
            var tarefa = await _tarefasServices.CompletarTarefa(id);

            return Ok(new { messagem = $"A tarefa {tarefa.Title} foi concluida!!!" });
        }
        catch (TarefasException te)
        {
            return NotFound(new { mensagem = te.Message });
        }
        catch (Exception ex)
        {

            return BadRequest(new { mensagem = ex.Message });
        }

    }

    [HttpPatch("incompletar/{id:int}")]
    public async Task<IActionResult> UncompleteTask(int id)
    {
        try
        {
            var tarefa = await _tarefasServices.CompletarTarefa(id);
            return Ok(new { messagem = $"A tarefa {tarefa.Title} voltou para não completada!!!" });
        }
        catch (TarefasException te)
        {
            return NotFound(new { mensagem = te.Message });
        }
        catch (Exception ex)
        {

            return BadRequest(new { mensagem = ex.Message });
        }

    }
}