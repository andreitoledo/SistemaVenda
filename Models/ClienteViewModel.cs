﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class ClienteViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage="Informe o nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ_CPF do cliente")]
        public string CNPJ_CPF { get; set; }

        [Required(ErrorMessage = "Informe o Email do cliente")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o celular do cliente")]
        public string Celular { get; set; }
       
    }
}
