using System;
using API.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace API.Models;

public class TarefaModel
{
    public TarefaModel()
    {
        
    }
    public TarefaModel(string title, 
                       string description, 
                       bool completed)
    {
        
        Title = title;
        Description = description;
        Completed = completed;

        Validar();
    }

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; }
    public DateTime CreatedDate { get;private set; } = DateTime.Now;

    public DateTime? UpdateDate { get;private set; }

    public void Alterar(string title,
                        string description,
                        bool completed)
    {
        Title = title;
        Description = description;
        Completed = completed;
        UpdateDate = DateTime.Now;
    }

    public void MarcarComoCompleta()
    {
        Completed = true;
    }

    public void MarcarComoIncompleta()
    {
        Completed = false;
    }

    private void Validar()
    {
        if(Title.Length > 20)
         throw new TarefasException("Quantidade de caracteres no titulo maior que a permitida (20)");

        if (Description.Length > 100)
         throw new TarefasException("Quantidade de caracteres na descrição maior que a permitida (100)");
    }


}