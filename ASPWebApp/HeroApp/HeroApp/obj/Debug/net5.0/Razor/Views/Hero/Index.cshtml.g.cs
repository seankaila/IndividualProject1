#pragma checksum "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\Hero\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "094dff5174e1620d0f1478a70cbf4b45078c0a55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hero_Index), @"mvc.1.0.view", @"/Views/Hero/Index.cshtml")]
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
#line 1 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\_ViewImports.cshtml"
using HeroApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\_ViewImports.cshtml"
using HeroApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"094dff5174e1620d0f1478a70cbf4b45078c0a55", @"/Views/Hero/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ab73294ddf5fd5f45640f356802f50390846ead", @"/Views/_ViewImports.cshtml")]
    public class Views_Hero_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HeroApp.Models.Hero>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\Hero\Index.cshtml"
  
    ViewData["Title"] = "Heros";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Heros</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\Hero\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Photo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\Hero\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Alias));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\Hero\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Power));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 26 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\Hero\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 625, "\"", 642, 1);
#nullable restore
#line 30 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\Hero\Index.cshtml"
WriteAttributeValue("", 631, item.Photo, 631, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height:128px;\" />\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 33 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\Hero\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Alias));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 36 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\Hero\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Power));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 40 "C:\Users\dharmindra.s.kaila\IndividualProject1\ASPWebApp\HeroApp\HeroApp\Views\Hero\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HeroApp.Models.Hero>> Html { get; private set; }
    }
}
#pragma warning restore 1591
