using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.Interface
{
    public interface ITarefasService
    {

        Task<TarefaModel> CompletarTarefa(int id);

        Task<TarefaModel> TornarTarefaIncompleta(int id);

        Task<IEnumerable<TarefaModel>> SelecioneTodas();

        Task<TarefaModel> SelecionePorId(int id);

        void Inserir(TarefaModel t);

        Task<TarefaModel> Atualizar(int id, TarefaModel t);

        Task<TarefaModel> Remover(int id);
    }
}
