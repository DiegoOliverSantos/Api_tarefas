using System.Xml.Schema;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {

        [HttpGet("")]
        public HomeViewModel Index(){
            return new HomeViewModel("Bem Vindo a API de tarefas", "/swagger");
        }
    }
}