using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ProdutoController : Controller
    {
        protected ApplicationDbContext mContext;

        public ProdutoController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Produto> lista = mContext.Produto.Include(x=>x.Categoria).ToList();
            mContext.Dispose();
            return View(lista);
        }

        private IEnumerable<SelectListItem> ListaCategoria()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty

            });

            foreach (var item in mContext.Categoria.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao.ToString()
                });
            }

            return lista;

        }

        // lista os dados do banco na tela
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();
            //carrega lista para o combo box
            viewModel.ListaCategorias = ListaCategoria();


            if (id != null)
            {
                var entidade = mContext.Produto.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
                viewModel.Quantidade = entidade.Quantidade;
                viewModel.Valor = entidade.Valor;
                viewModel.CodigoCategoria = entidade.CodigoCategoria;

            }
            
            return View(viewModel);

        }

        // inclui ou altera os dados
        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            // verifica a validação da model
            if (ModelState.IsValid)
            {
                Produto objProduto = new Produto()
                {
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao,
                    Quantidade = entidade.Quantidade,
                    Valor = (decimal)entidade.Valor,
                    CodigoCategoria = (int)entidade.CodigoCategoria
                };

                // se o codigo vier nulo preenche
                if (entidade.Codigo == null)
                {
                    mContext.Produto.Add(objProduto);
                }
                // se vier preenchido altera
                else
                {
                    mContext.Entry(objProduto).State = EntityState.Modified;
                }
                mContext.SaveChanges();
            }
            else
            {
                entidade.ListaCategorias = ListaCategoria();
                return View(entidade);
            }

            return RedirectToAction("index");

        }

        // exclui os dados
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var ent = new Produto() { Codigo = id };
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();
            
            return RedirectToAction("Index");

        }
    }
}
