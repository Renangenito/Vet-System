using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace VetSystem.Controllers
{
    public class LoginController : Controller
    {
            public IActionResult Index()
            {
                return View();
            }


            public async Task<JsonResult> Entrar(string usuario, string senha)
            {
                try
                {
                    if ((usuario == "usuarioRenan" && senha == "senhaRenan")
                        || (usuario == "adminRenan" && senha == "senhaRenan"))
                    {
                        var identity = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.NameIdentifier, usuario),
                        new Claim(ClaimTypes.Role, usuario == "usuarioRenan" ? "usuario" : "administrador"),
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        return Json("OK");
                    }
                    else
                    {
                        TempData["erroLogin"] = "Usuário ou Senha inválido!";
                        return Json("Usuário ou Senha inválido!");
                    }
                }
                catch (Exception)
                {
                    TempData["erroLogin"] = "Usuário ou Senha inválido!";
                    return Json("Usuário ou Senha inválido!");
                }
            }
        }
}
