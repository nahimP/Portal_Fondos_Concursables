using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace TuProyecto.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        // ✅ Lista pública y estática para acceder desde LoginModel
        public static List<User> Users = new List<User>();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Las contraseñas no coinciden";
                return Page();
            }

            if (Users.Any(u => u.Username == Username))
            {
                ErrorMessage = "El usuario ya existe";
                return Page();
            }

            Users.Add(new User { Username = Username, Password = Password });
            SuccessMessage = "Usuario registrado correctamente. Ahora puedes iniciar sesión.";

            return Page();
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; } // En producción usar hash
    }
}