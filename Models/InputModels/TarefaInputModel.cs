namespace API.Models.InputModels;

public class TarefaInputModel
{

    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set;} = string.Empty;

    public bool Completada { get; set; }

    public TarefaInputModel(string titulo,
                             string descricao,
                             bool completada)
    {
        Titulo = titulo;
        Descricao = descricao;
        Completada = completada;
    }

}