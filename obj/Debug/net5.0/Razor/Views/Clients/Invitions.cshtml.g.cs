#pragma checksum "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "987c56ad61f6974ca45fb14f9c40d320042b8549"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clients_Invitions), @"mvc.1.0.view", @"/Views/Clients/Invitions.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"987c56ad61f6974ca45fb14f9c40d320042b8549", @"/Views/Clients/Invitions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7382dd3c129ccafb293208743c1af92e67834108", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Clients_Invitions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KhadimiEssa.Data.TableDb.UserInvitation>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
  
    ViewBag.Title = "المستخدمين";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""card-box"">

    <h2 class=""header-title m-t-0 m-b-30"">العملاء</h2>

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
                        الصورة الشخصية
                    </th>
                    <th>
                        الحالة
                    </th>
                    <th>
                        تغيير الحالة
                    </th>
");
            WriteLiteral("                </tr>\r\n            </thead>\r\n            <tbody style=\"text-align:center\">\r\n");
#nullable restore
#line 39 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 43 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
                       Write(Html.DisplayFor(modelItem => item.User.user_Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 46 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
                       Write(Html.DisplayFor(modelItem => item.User.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1472, "\"", 1499, 1);
#nullable restore
#line 49 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
WriteAttributeValue("", 1478, item.User.ImgProfile, 1478, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100px; height:100px; \" />\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 52 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
                              
                                if (item.User.IsActive == true)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <label");
            BeginWriteAttribute("id", " id=\"", 1776, "\"", 1794, 1);
#nullable restore
#line 55 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
WriteAttributeValue("", 1781, item.User.Id, 1781, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:green;font-size: 17px;\">مفعل</label>\r\n");
#nullable restore
#line 56 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <label");
            BeginWriteAttribute("id", " id=\"", 1997, "\"", 2015, 1);
#nullable restore
#line 59 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
WriteAttributeValue("", 2002, item.User.Id, 2002, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:red;font-size: 17px;\">غير مفعل</label>\r\n");
#nullable restore
#line 60 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>\r\n                            <input type=\"button\" value=\"تغيير الحالة\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2266, "\"", 2303, 3);
            WriteAttributeValue("", 2276, "Validation(\'", 2276, 12, true);
#nullable restore
#line 64 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
WriteAttributeValue("", 2288, item.User.Id, 2288, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2301, "\')", 2301, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-purple btn-rounded\" />\r\n                        </td>\r\n");
            WriteLiteral("\r\n                    </tr>\r\n");
#nullable restore
#line 71 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Clients\Invitions.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n        <!-- -------------------------------------------------------------------------------------------------- -->\r\n    </div><!-- end row -->\r\n</div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>

        function Validation(id) {
            $.ajax({
                url: ""/Clients/ChangeState"",
                type: ""POST"",
                dataType: ""json"",
                data: {
                    id: id
                },
                success: function (result) {

                    if (result.data == true) {
                        $('#' + id).css('color', 'green');
                        $('#' + id).html('مفعل');
                    } else if (result.data == false) {
                        $('#' + id).css('color', 'red');
                        $('#' + id).html('غير مفعل');

                    }
                },
                failure: function (info) {

                }
            });
        }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KhadimiEssa.Data.TableDb.UserInvitation>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591