#pragma checksum "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c1adbf152ab6b0b7a65d1b1768a14f93d5ef6df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notes_Index), @"mvc.1.0.view", @"/Views/Notes/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c1adbf152ab6b0b7a65d1b1768a14f93d5ef6df", @"/Views/Notes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7382dd3c129ccafb293208743c1af92e67834108", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Notes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KhadimiEssa.Data.TableDb.Note>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<<div class=\"card-box\">\r\n");
            WriteLiteral("\r\n    <h2 class=\"header-title m-t-0 m-b-30\"> الملاحظات</h2>\r\n\r\n    <div>\r\n        <p>\r\n            ");
#nullable restore
#line 14 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
       Write(Html.ActionLink("اضافة", "Create", "Notes", null, new { @class = "btn btn-primary btn-rounded w-md waves-effect waves-light m-b-5" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </p>
        <table id=""datatable-responsive"" class=""table table-striped table-bordered dt-responsive nowrap"" cellspacing=""0"" width=""100%"">
            <thead style=""text-align:center"">
                <tr>
                    <th>النص بالعربية</th>
                    <th>النص بالانجليزية</th>
                    <th> الحالة </th>
                    <th>تغيير الحالة </th>
                    <th>تعديل </th>
                    <th>حذف </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 28 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 32 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NameAr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 35 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NameEn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 38 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
                              
                                if (item.IsActive == true)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <label");
            BeginWriteAttribute("id", " id=\"", 1522, "\"", 1535, 1);
#nullable restore
#line 41 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
WriteAttributeValue("", 1527, item.Id, 1527, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:green;font-size: 17px;\">مفعل</label>\r\n");
#nullable restore
#line 42 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <label");
            BeginWriteAttribute("id", " id=\"", 1738, "\"", 1751, 1);
#nullable restore
#line 45 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
WriteAttributeValue("", 1743, item.Id, 1743, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:red;font-size: 17px;\">غير مفعل</label>\r\n");
#nullable restore
#line 46 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>\r\n                            <input type=\"button\" value=\"تغيير الحالة\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2002, "\"", 2034, 3);
            WriteAttributeValue("", 2012, "ChangeStatus(", 2012, 13, true);
#nullable restore
#line 50 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
WriteAttributeValue("", 2025, item.Id, 2025, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2033, ")", 2033, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-purple btn-rounded\" />\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 54 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
                       Write(Html.ActionLink("تعديل", "Edit", new { id = item.Id }, new { @class = "btn btn-info btn-rounded" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            <input type=\"button\" value=\"حذف\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2391, "\"", 2417, 3);
            WriteAttributeValue("", 2401, "Delete(", 2401, 7, true);
#nullable restore
#line 58 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
WriteAttributeValue("", 2408, item.Id, 2408, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2416, ")", 2416, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-purple btn-rounded\" />\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 61 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Notes\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n        <!-- -------------------------------------------------------------------------------------------------- -->\r\n    </div><!-- end row -->\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"

    <script>

        function ChangeStatus(id) {
            $.ajax({
                url: ""/Notes/ChangeState"",
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

        function Delete(id) {
            Swal.fire({
                title: 'هل انت متاكد من حذف هذا العنصر  ؟',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
         ");
                WriteLiteral(@"       cancelButtonColor: '#3085d6',
                cancelButtonText: 'اغلاق',
                confirmButtonText: 'حذف',
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        url: ""/Notes/Delete"",
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
                            window.location.reload();
                        },
                        failure: function (info) {

                        }
                    })
                }
            })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KhadimiEssa.Data.TableDb.Note>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
