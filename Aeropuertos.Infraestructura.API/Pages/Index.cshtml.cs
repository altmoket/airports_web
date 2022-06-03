using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace Aeropuertos.Infraestructura.API.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; private set; } = "PageModel in C#";
        public string Titulo {get; private set;} = string.Empty;

        public void OnGet()
        {
            Titulo = "Aeropuertos App";
            Message = "Para disfrutar en familia";
        }
    }
}