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
    public class CategoriaController : Controller
    {
        protected ApplicationDbContext mContext;

        public CategoriaController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = mContext.Categoria.ToList();
            mContext.Dispose();
            return View(lista);
        }

        // lista os dados do banco na tela
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();

            if (id != null)
            {
                var entidade = mContext.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;

            }
            
            return View(viewModel);

        }

        // inclui ou altera os dados
        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            // verifica a validação da model
            if (ModelState.IsValid)
            {
                Categoria objCategoria = new Categoria()
                {
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao
                };

                // se o codigo vier nulo preenche
                if (entidade.Codigo == null)
                {
                    mContext.Categoria.Add(objCategoria);
                }
                // se vier preenchido altera
                else
                {
                    mContext.Entry(objCategoria).State = EntityState.Modified;
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
            var ent = new Categoria() { Codigo = id };
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            
            return RedirectToAction("Index");

        }
    }
}
