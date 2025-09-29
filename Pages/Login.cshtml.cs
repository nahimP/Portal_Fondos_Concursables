using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Linq;

namespace TuProyecto.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            // ✅ Buscar usuario en la lista estática de RegisterModel
            var user = RegisterModel.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);

            if (user != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, Username) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToPage("/Index");
            }

            ErrorMessage = "Usuario o contraseña incorrectos";
            return Page();
        }
    }
}
