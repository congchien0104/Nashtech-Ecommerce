#pragma checksum "C:\Users\User\source\Nastech\Nashtech-Ecommerce\Nashtech-Ecommerce\Views\Shared\_Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cd7590d835c3d9aaa5a39fb5bb7d72f2085a297"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Categories), @"mvc.1.0.view", @"/Views/Shared/_Categories.cshtml")]
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
#line 1 "C:\Users\User\source\Nastech\Nashtech-Ecommerce\Nashtech-Ecommerce\Views\_ViewImports.cshtml"
using Nashtech_Ecommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\Nastech\Nashtech-Ecommerce\Nashtech-Ecommerce\Views\_ViewImports.cshtml"
using Nashtech_Ecommerce.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cd7590d835c3d9aaa5a39fb5bb7d72f2085a297", @"/Views/Shared/_Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a69a03b0afb2db2762169d56e5cfed0b5e037135", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Nashtech_Ecommerce.Models.Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<li class=""nav-item dropdown"">
    <a class=""nav-link dropdown-toggle text-info"" href=""#"" id=""navbarDropdown"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
        Categories
    </a>
    <div class=""dropdown-menu"" aria-labelledby=""navbarDropdown"">
");
#nullable restore
#line 8 "C:\Users\User\source\Nastech\Nashtech-Ecommerce\Nashtech-Ecommerce\Views\Shared\_Categories.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a class=\"dropdown-item\" href=\"/\">");
#nullable restore
#line 10 "C:\Users\User\source\Nastech\Nashtech-Ecommerce\Nashtech-Ecommerce\Views\Shared\_Categories.cshtml"
                                         Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 11 "C:\Users\User\source\Nastech\Nashtech-Ecommerce\Nashtech-Ecommerce\Views\Shared\_Categories.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</li>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Nashtech_Ecommerce.Models.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
