#pragma checksum "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\IntroContactUs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8624b5b4edb9a5a493717c39c815d47a1edfb5f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IntroContactUs_Index), @"mvc.1.0.view", @"/Views/IntroContactUs/Index.cshtml")]
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
#line 1 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\_ViewImports.cshtml"
using KhadimiEssa;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\_ViewImports.cshtml"
using KhadimiEssa.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8624b5b4edb9a5a493717c39c815d47a1edfb5f9", @"/Views/IntroContactUs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7382dd3c129ccafb293208743c1af92e67834108", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_IntroContactUs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KhadimiEssa.Data.TableDb.IntroductorySite.IntroContactUs>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\IntroContactUs\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card-box\">\r\n");
            WriteLiteral(@"    <h2 class=""header-title m-t-0 m-b-30"">تواصل معنا</h2>
    <div>
        <table id=""datatable-responsive"" class=""table table-striped table-bordered dt-responsive nowrap"" cellspacing=""0"" width=""100%"">
            <thead>
                <tr>
                    <th>
                        الاسم
                    </th>
                    <th>
                        رقم الجوال
                    </th>
                    <th>
                        الاميل
                    </th>
                    <th>
                        الرسالة
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 30 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\IntroContactUs\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 34 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\IntroContactUs\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 37 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\IntroContactUs\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 40 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\IntroContactUs\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 43 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\IntroContactUs\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 46 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\IntroContactUs\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n        <!-- -------------------------------------------------------------------------------------------------- -->\r\n    </div><!-- end row -->\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KhadimiEssa.Data.TableDb.IntroductorySite.IntroContactUs>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
