#pragma checksum "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7b8aedde0356a7d33cb4f845d3d203c8a7c61bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PaymentMethods_Index), @"mvc.1.0.view", @"/Views/PaymentMethods/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7b8aedde0356a7d33cb4f845d3d203c8a7c61bd", @"/Views/PaymentMethods/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7382dd3c129ccafb293208743c1af92e67834108", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_PaymentMethods_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KhadimiEssa.Data.TableDb.PaymentMethod>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PaymentMethods", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-purple btn-rounded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
  
    ViewBag.Title = "?????????? ??????????";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card-box\">\r\n");
            WriteLiteral("    <h2 class=\"header-title m-t-0 m-b-30\">?????????? ??????????</h2>\r\n    <div>\r\n        <!-- -------------------------------------------------------------------------------------------------- -->\r\n\r\n        <p>\r\n            ");
#nullable restore
#line 15 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
       Write(Html.ActionLink("?????????? ?????????? ?????? ", "Create", "PaymentMethods", null, new { @class = "btn btn-primary btn-rounded w-md waves-effect waves-light m-b-5" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </p>


        <table id=""datatable-responsive"" class=""table table-striped table-bordered dt-responsive nowrap"" cellspacing=""0"" width=""100%"">
            <thead>
                <tr>
                    <th style=""text-align:center"">
                        ?????????? ????????????????
                    </th>
                    <th style=""text-align:center"">
                        ?????????? ??????????????????????
                    </th>
                   
                    <th style=""text-align:center"">
                        ????????????
                    </th>
                    <th style=""text-align:center"">
                        ?????????? ????????????
                    </th>
                    <th style=""text-align:center"">
                        ??????????
                    </th>
                    <th style=""text-align:center"">
                        ?????? 
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 44 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 48 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NameAr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 51 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NameEn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 54 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
                              
                                if (item.IsActive == true)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <label");
            BeginWriteAttribute("id", " id=\"", 2108, "\"", 2121, 1);
#nullable restore
#line 57 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
WriteAttributeValue("", 2113, item.Id, 2113, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:green;font-size: 17px;\">????????</label>\r\n");
#nullable restore
#line 58 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <label");
            BeginWriteAttribute("id", " id=\"", 2324, "\"", 2337, 1);
#nullable restore
#line 61 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
WriteAttributeValue("", 2329, item.Id, 2329, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:red;font-size: 17px;\">?????? ????????</label>\r\n");
#nullable restore
#line 62 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n\r\n                        <td>\r\n                            <input type=\"button\" value=\"???????? ????????????\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2589, "\"", 2620, 3);
            WriteAttributeValue("", 2599, "Validtion(\'", 2599, 11, true);
#nullable restore
#line 67 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
WriteAttributeValue("", 2610, item.Id, 2610, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2618, "\')", 2618, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-purple btn-rounded\" />\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7b8aedde0356a7d33cb4f845d3d203c8a7c61bd9460", async() => {
                WriteLiteral("??????????");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
                                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n");
            WriteLiteral("\r\n                        <td>\r\n                            <input type=\"button\" value=\"??????\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3213, "\"", 3241, 3);
            WriteAttributeValue("", 3223, "Delete(\'", 3223, 8, true);
#nullable restore
#line 78 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
WriteAttributeValue("", 3231, item.Id, 3231, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3239, "\')", 3239, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-purple btn-rounded\" />\r\n                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 82 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\PaymentMethods\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n\r\n        </table>\r\n    </div><!-- end row -->\r\n</div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        function Validtion(id) {
            $.ajax({
                url: ""/PaymentMethods/ChangeState"",
                type: ""POST"",
                dataType: ""json"",
                data: {
                    id: id
                },
                success: function (result) {

                    if (result.data == true) {
                        $('#' + id).css('color', 'green');
                        $('#' + id).html('????????');

                    } else if (result.data == false) {
                        $('#' + id).css('color', 'red');
                        $('#' + id).html('?????? ????????');

                    }
                },
                failure: function (info) {

                }
            });

        }

        function Delete(id) {
            Swal.fire({
                title: '???? ?????? ?????????? ???? ?????? ?????? ????????????  ??',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
   ");
                WriteLiteral(@"             cancelButtonColor: '#3085d6',
                cancelButtonText: '??????????',
                confirmButtonText: '??????',
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        url: ""/PaymentMethods/Delete"",
                        type: ""POST"",
                        dataType: ""json"",
                        data: {
                            id: id
                        }, success: function (result) {
                            if (result.data == true) {
                                toastr.success(""???? ?????????? ??????????"");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KhadimiEssa.Data.TableDb.PaymentMethod>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
