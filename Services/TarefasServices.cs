using System.Collections.Generic;
using System.Threading.Tasks;
using API.Database;
using API.Exceptions;
using API.Models;
using API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class TarefasServices : ITarefasService
{
    private readonly TarefaContext _context;
    public TarefasServices(TarefaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TarefaModel>> SelecioneTodas()
    {
        return await _context.Tarefas.ToListAsync();
    }

    public  async Task<TarefaModel> SelecionePorId(int id)
    {
        var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

        if (tarefa is null)
            throw new TarefasException($"Tarefa do id {id} não encontrada");
        
        return tarefa;
    }

    public void Inserir(TarefaModel tarefaModel)
    {
        _context.Tarefas.Add(tarefaModel);
        _context.SaveChanges();
    }

    public async Task<TarefaModel> Atualizar(int id, TarefaModel tarefaModel)
    {
        var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

        if (tarefa is null)
            throw new TarefasException($"Tarefa do id {id} não encontrada");

        tarefa.Alterar(tarefaModel.Title,
                       tarefaModel.Description,
                       tarefaModel.Completed);
        
        _context.Tarefas.Update(tarefa);

        await _context.SaveChangesAsync();

        return tarefa;
    }

    public async Task<TarefaModel> Remover(int id)
    {
        var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

        if(tarefa is null)
            throw new TarefasException($"a Tarefa de id {id} não foi localizada");

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();

        return tarefa;
    }
    public async Task<TarefaModel> CompletarTarefa(int id)
    {
         var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

        if (tarefa is null)
            throw new TarefasException($"Tarefa de id {id} não encontrada");

        tarefa.MarcarComoCompleta();

        _context.Update(tarefa);
        await _context.SaveChangesAsync();

        return tarefa;

    }

    public async Task<TarefaModel> TornarTarefaIncompleta(int id)
    {
         var tarefa = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

        if (tarefa is null)
            throw new TarefasException($"Tarefa de id {id} não encontrada");

        tarefa.MarcarComoIncompleta();

        _context.Update(tarefa);
        await _context.SaveChangesAsync();

        return tarefa;
    }
}