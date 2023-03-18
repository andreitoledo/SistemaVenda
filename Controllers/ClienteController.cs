using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Controllers
{
    public class ClienteController : Controller
    {
        protected ApplicationDbContext mContext;

        public ClienteController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = mContext.Cliente.ToList();
            mContext.Dispose();
            return View(lista);
        }

        // lista os dados do banco na tela
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new ClienteViewModel();

            if (id != null)
            {
                var entidade = mContext.Cliente.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Nome = entidade.Nome;
                viewModel.CNPJ_CPF = entidade.CNPJ_CPF;
                viewModel.Email = entidade.Email;
                viewModel.Celular = entidade.Celular;

            }
            
            return View(viewModel);

        }

        // inclui ou altera os dados
        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            // verifica a validação da model
            if (ModelState.IsValid)
            {
                Cliente objCliente = new Cliente()
                {
                    Codigo = entidade.Codigo,
                    Nome = entidade.Nome,
                    CNPJ_CPF = entidade.CNPJ_CPF,
                    Email = entidade.Email,
                    Celular = entidade.Celular
                };

                // se o codigo vier nulo preenche
                if (entidade.Codigo == null)
                {
                    mContext.Cliente.Add(objCliente);
                }
                // se vier preenchido altera
                else
                {
                    mContext.Entry(objCliente).State = EntityState.Modified;
                }
                mContext.SaveChanges();
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("index");

        }

        // exclui os dados
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var ent = new Cliente() { Codigo = id };
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            
            return RedirectToAction("Index");

        }
    }
}
