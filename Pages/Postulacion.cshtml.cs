using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TuProyecto.Pages
{
    public class PostulacionModel : PageModel
    {
        // Nombre del fondo que se pasa por query string
        [BindProperty(SupportsGet = true)]
        public string Fondo { get; set; }

        [BindProperty]
        public string Nombre { get; set; }

        [BindProperty]
        public string TipoPostulante { get; set; }

        [BindProperty]
        public string TipoFinanciamiento { get; set; }

        [BindProperty]
        public string Correo { get; set; }

        [BindProperty]
        public string Comentarios { get; set; }

        public string Mensaje { get; set; }

        // Lista est�tica temporal de postulaciones
        public static List<Postulante> Postulaciones = new List<Postulante>();

        public void OnGet()
        {
            // Aqu� se puede usar Fondo si se quiere mostrar el nombre del fondo en la p�gina
        }

        public IActionResult OnPost()
        {
            // Guardar la postulaci�n incluyendo el fondo
            Postulaciones.Add(new Postulante
            {
                Fondo = Fondo,
                Nombre = Nombre,
                TipoPostulante = TipoPostulante,
                TipoFinanciamiento = TipoFinanciamiento,
                Correo = Correo,
                Comentarios = Comentarios
            });

            Mensaje = "Postulaci�n enviada correctamente!";
            return Page();
        }
    }

    public class Postulante
    {
        public string Fondo { get; set; }
        public string Nombre { get; set; }
        public string TipoPostulante { get; set; }
        public string TipoFinanciamiento { get; set; }
        public string Correo { get; set; }
        public string Comentarios { get; set; }
    }
}


