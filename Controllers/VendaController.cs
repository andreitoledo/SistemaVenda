using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {
        protected ApplicationDbContext mContext;

        public VendaController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Venda> lista = mContext.Venda.ToList();
            mContext.Dispose();
            return View(lista);
        }

        // listagem de produtos
        private IEnumerable<SelectListItem> ListaProdutos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty

            });

            foreach (var item in mContext.Produto.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao.ToString()
                });
            }

            return lista;

        }

        // listagem de clientes
        private IEnumerable<SelectListItem> ListaClientes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty

            });

            foreach (var item in mContext.Cliente.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome.ToString()
                });
            }

            return lista;

        }

        // lista os dados do banco para redenrizar em tela
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();
            //carrega lista para o combo box
            viewModel.ListaClientes = ListaClientes();
            viewModel.ListaProdutos = ListaProdutos();


            if (id != null)
            {
                var entidade = mContext.Venda.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Data = entidade.Data;
                viewModel.CodigoCliente = entidade.CodigoCliente;
                viewModel.Total = entidade.Total;

            }

            return View(viewModel);

        }

        // recebe os dados para inclusão ou edição
        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            // verifica a validação da model
            if (ModelState.IsValid)
            {
                Venda objVenda = new Venda()
                {
                    Codigo = entidade.Codigo,
                    Data = (DateTime)entidade.Data,
                    CodigoCliente = (int)entidade.CodigoCliente,
                    Total = entidade.Total,
                    Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(entidade.JsonProdutos)
                };

                // se o codigo vier nulo preenche
                if (entidade.Codigo == null)
                {
                    mContext.Venda.Add(objVenda);
                }
                // se vier preenchido altera
                else
                {
                    mContext.Entry(objVenda).State = EntityState.Modified;
                }
                mContext.SaveChanges();
            }
            else
            {
                entidade.ListaClientes = ListaClientes();
                entidade.ListaProdutos = ListaProdutos();

                return View(entidade);
            }

            return RedirectToAction("index");

        }

        // exclui os dados
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var ent = new Venda() { Codigo = id };
            mContext.Attach(ent);
            mContext.Remove(ent);
            mContext.SaveChanges();

            return RedirectToAction("Index");

        }

        // Método para preencher o valor do produto em Vendas
        [HttpGet("LerValorProduto/{codigoProduto}")]
        public decimal LerValorProduto(int codigoProduto)
        {
            return mContext.Produto.Where(x => x.Codigo == codigoProduto).Select(x => x.Valor).FirstOrDefault();
        }

    }
}
