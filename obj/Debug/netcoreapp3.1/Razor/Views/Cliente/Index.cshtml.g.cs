#pragma checksum "C:\Users\andre\source\repos\SistemaVenda\Views\Cliente\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a9397e4fb9d42df53809cbbaa4c6fed643adcf8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cliente_Index), @"mvc.1.0.view", @"/Views/Cliente/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\andre\source\repos\SistemaVenda\Views\_ViewImports.cshtml"
using SistemaVenda;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andre\source\repos\SistemaVenda\Views\_ViewImports.cshtml"
using SistemaVenda.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a9397e4fb9d42df53809cbbaa4c6fed643adcf8", @"/Views/Cliente/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9542d2a040dc74eba97c4a394c73aefd7909e77c", @"/Views/_ViewImports.cshtml")]
    public class Views_Cliente_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SistemaVenda.Entidades.Cliente>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\andre\source\repos\SistemaVenda\Views\Cliente\Index.cshtml"
  
    ViewData["Title"] = "Clientes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<h2>Clientes</h2>
<hr />

<table class=""table table-bordered"">
    <thead>
        <tr style=""background-color:#f6f6f6"">
            <th>Código</th>
            <th>Nome</th>
            <th>CNPJ_CPF</th>
            <th>Email</th>
            <th>Celular</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 21 "C:\Users\andre\source\repos\SistemaVenda\Views\Cliente\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr");
            BeginWriteAttribute("onclick", " onclick=\"", 468, "\"", 498, 3);
            WriteAttributeValue("", 478, "Editar(", 478, 7, true);
#nullable restore
#line 23 "C:\Users\andre\source\repos\SistemaVenda\Views\Cliente\Index.cshtml"
WriteAttributeValue("", 485, item.Codigo, 485, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 497, ")", 497, 1, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"cursor:pointer;\">\r\n            <td>");
#nullable restore
#line 24 "C:\Users\andre\source\repos\SistemaVenda\Views\Cliente\Index.cshtml"
           Write(item.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "C:\Users\andre\source\repos\SistemaVenda\Views\Cliente\Index.cshtml"
           Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\andre\source\repos\SistemaVenda\Views\Cliente\Index.cshtml"
           Write(item.CNPJ_CPF);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\andre\source\repos\SistemaVenda\Views\Cliente\Index.cshtml"
           Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "C:\Users\andre\source\repos\SistemaVenda\Views\Cliente\Index.cshtml"
           Write(item.Celular);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 30 "C:\Users\andre\source\repos\SistemaVenda\Views\Cliente\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>
<br />
<button type=""button"" class=""btn btn-block btn-primary"" onclick=""Cadastrar()"">Cadastrar Cliente</button>

<script>
    function Editar(codigo) {
        window.location = window.origin + ""\\Cliente\\Cadastro\\"" + codigo;
    }

    function Cadastrar() {
        window.location = window.origin + ""\\Cliente\\Cadastro"";
    }
</script>


");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SistemaVenda.Entidades.Cliente>> Html { get; private set; }
    }
}
#pragma warning restore 1591