#pragma checksum "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71f39af6604ecaa6c75258b2c2d633767a08b65e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DContactUs_Index), @"mvc.1.0.view", @"/Views/DContactUs/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71f39af6604ecaa6c75258b2c2d633767a08b65e", @"/Views/DContactUs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7382dd3c129ccafb293208743c1af92e67834108", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_DContactUs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KhadimiEssa.Data.TableDb.ContactUs>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""card-box"">
    <h2 class=""header-title m-t-0 m-b-30"">الشكاوى و المقترحات</h2>
    <div>

        <table id=""datatable-responsive"" class=""table table-striped table-bordered dt-responsive nowrap"" cellspacing=""0"" width=""100%"">
            <thead>
                <tr>
                    <th>
                        الرقم
                    </th>
                    <th>
                        الاسم
                    </th>
                    <th>
                        الاميل
                    </th>
                    <th>
                        رقم الهاتف
                    </th>
                    <th>
                        الشكوى
                    </th>
                    <th>
                        التاريخ
                    </th>
                    <th>
                        حذف
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 41 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 45 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 48 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 51 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                         <td>\r\n                            ");
#nullable restore
#line 54 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 57 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Msg));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 60 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                         <td>\r\n                            <input type=\"button\" value=\"حذف\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2069, "\"", 2095, 3);
            WriteAttributeValue("", 2079, "Delete(", 2079, 7, true);
#nullable restore
#line 63 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml"
WriteAttributeValue("", 2086, item.Id, 2086, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2094, ")", 2094, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-purple btn-rounded\" />\r\n                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 67 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DContactUs\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n\r\n        <!-- -------------------------------------------------------------------------------------------------- -->\r\n    </div><!-- end row -->\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function Delete(id) {
            Swal.fire({
                title: 'هل انت متاكد من حذف هذا العنصر  ؟',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#3085d6',
                cancelButtonText: 'اغلاق',
                confirmButtonText: 'حذف',
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        url: ""/DContactUs/Delete"",
                        type: ""POST"",
                        dataType: ""json"",
                        data: {
                            id: id
                        }, success: function (result) {
                            if (result.data == true) {
                                toastr.success(""تم الحذف بنجاح"");
                                setTimeout(function () {
                                }, 3000);
                            }
                    ");
                WriteLiteral("        window.location.reload();\r\n                        },\r\n                        failure: function (info) {\r\n\r\n                        }\r\n                    })\r\n                }\r\n            })\r\n        }\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KhadimiEssa.Data.TableDb.ContactUs>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
