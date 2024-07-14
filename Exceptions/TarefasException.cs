using System;

namespace API.Exceptions;

public class TarefasException : Exception{
    public TarefasException(string message) : base(message) { }
}