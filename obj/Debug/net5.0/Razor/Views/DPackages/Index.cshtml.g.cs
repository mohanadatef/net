#pragma checksum "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "add6b888bb61a3fd48a5a6057092ac41bacd8d54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DPackages_Index), @"mvc.1.0.view", @"/Views/DPackages/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"add6b888bb61a3fd48a5a6057092ac41bacd8d54", @"/Views/DPackages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7382dd3c129ccafb293208743c1af92e67834108", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_DPackages_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KhadimiEssa.Data.TableDb.Package>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card-box\">\r\n");
            WriteLiteral("\r\n    <h2 class=\"header-title m-t-0 m-b-30\">الباقات</h2>\r\n\r\n    <div>\r\n        <p>\r\n            ");
#nullable restore
#line 15 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
       Write(Html.ActionLink("اضافة باقه", "Create", "DPackages", null, new { @class = "btn btn-primary btn-rounded w-md waves-effect waves-light m-b-5" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </p>
        <table id=""datatable-responsive"" class=""table table-striped table-bordered dt-responsive "" cellspacing=""0"" width=""100%"">
            <thead>
                <tr>
                    <th>العنوان بالعربية</th>
                    <th>العنوان بالانجليزية</th>
                    <th>الوصف بالعربية</th>
                    <th>الوصف بالانجليزية</th>
                    <th> السعر </th>
                    <th> الحالة </th>
                    <th> تغيير الحاله </th>
                    <th> تعديل </th>
                    <th> حذف </th>

                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 33 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 37 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NameAr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 41 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NameEn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 45 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DescriptionAr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 49 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DescriptionEn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                         <td>\r\n                            ");
#nullable restore
#line 53 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n");
#nullable restore
#line 57 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                              
                                if (item.IsActive == true)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <label");
            BeginWriteAttribute("id", " id=\"", 2110, "\"", 2123, 1);
#nullable restore
#line 60 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
WriteAttributeValue("", 2115, item.Id, 2115, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:green;font-size: 17px;\">مفعل</label>\r\n");
#nullable restore
#line 61 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <label");
            BeginWriteAttribute("id", " id=\"", 2326, "\"", 2339, 1);
#nullable restore
#line 64 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
WriteAttributeValue("", 2331, item.Id, 2331, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:red;font-size: 17px;\">غير مفعل</label>\r\n");
#nullable restore
#line 65 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n\r\n                        <td>\r\n                            <input type=\"button\" value=\"تغيير الحالة\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2592, "\"", 2624, 3);
            WriteAttributeValue("", 2602, "Validation(\'", 2602, 12, true);
#nullable restore
#line 70 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
WriteAttributeValue("", 2614, item.Id, 2614, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2622, "\')", 2622, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-purple btn-rounded\" />\r\n                        </td>\r\n                        \r\n                        <td>\r\n                            ");
#nullable restore
#line 74 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                       Write(Html.ActionLink("تعديل", "Edit", new { id = item.Id }, new { @class = "btn btn-info btn-rounded" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <input type=\"button\" value=\"حذف\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3003, "\"", 3031, 3);
            WriteAttributeValue("", 3013, "Delete(\'", 3013, 8, true);
#nullable restore
#line 77 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
WriteAttributeValue("", 3021, item.Id, 3021, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3029, "\')", 3029, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-purple btn-rounded\" />\r\n                        </td>\r\n                        \r\n                       \r\n                    </tr>\r\n");
#nullable restore
#line 82 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\DPackages\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>

        <!-- -------------------------------------------------------------------------------------------------- -->
    </div><!-- end row -->
</div>


<div class=""modal fade"" id=""PackageModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">المشتركين</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <table id=""packages-table"" class=""table table-striped table-bordered dt-responsive nowrap"" cellspacing=""0"" width=""100%"">

                    <tbody>
                    </tbody>
                </table>
            </div>
");
            WriteLiteral("            <div class=\"modal-footer\">\r\n                <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">اغلاق</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
<script>

    function Validation(id) {
        $.ajax({
            url: ""/DPackages/ChangeState"",
            type: ""POST"",
            dataType: ""json"",
            data: {
                id: id
            },
            success: function (result) {

                if (result.data == true) {
                    $('#' + id).css('color', 'green');
                    $('#' + id).html('مفعل');
                   // location.reload();
                } else if (result.data == false) {
                    $('#' + id).css('color', 'red');
                    $('#' + id).html('غير مفعل');
                   // location.reload();
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
                can");
                WriteLiteral(@"celButtonColor: '#3085d6',
                cancelButtonText: 'اغلاق',
                confirmButtonText: 'حذف',
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        url: ""/DPackages/Delete"",
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
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KhadimiEssa.Data.TableDb.Package>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
