using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAL;
using SistemaVenda.Helpers;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Controllers
{
    public class LoginController : Controller
    {
        protected ApplicationDbContext mContext;
        protected IHttpContextAccessor httpContextAccessor;

        public LoginController(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            mContext = context;
            httpContextAccessor = httpContext;

        }

        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    httpContextAccessor.HttpContext.Session.Clear();                    
                }

            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {

            ViewData["ErroLogin"] = string.Empty;
            if (ModelState.IsValid)
            {
                var Senha = Cryptografia.getMD5Hash(model.Senha);
                var usuario = mContext.Usuario.Where(x => x.Email == model.Email
                && x.Senha == Senha).FirstOrDefault();

                if (usuario == null)
                {
                    ViewData["ErroLogin"] = "Email ou Senha informados não existe no sistema !";
                    return View(model);

                }else
                {
                    
                    //coloca os dados do usuario na sessão
                    httpContextAccessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    httpContextAccessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    httpContextAccessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                    httpContextAccessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }           
        }
    }
}
