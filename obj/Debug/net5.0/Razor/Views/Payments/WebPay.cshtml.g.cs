#pragma checksum "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Payments\WebPay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bca79aa112a3d0f656ae129cc88bca8d7a88c11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payments_WebPay), @"mvc.1.0.view", @"/Views/Payments/WebPay.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bca79aa112a3d0f656ae129cc88bca8d7a88c11", @"/Views/Payments/WebPay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7382dd3c129ccafb293208743c1af92e67834108", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Payments_WebPay : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("paymentWidgets"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-brands", new global::Microsoft.AspNetCore.Html.HtmlString("VISA MASTER"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Payments\WebPay.cshtml"
  
    ViewBag.Title = "Pay";
    //Layout = "~/Views/Shared/_Layout.cshtml";
    Layout = null;
    var checkOutId = ViewBag.Id;
    var userId = ViewBag.userId;
    var paymentId = ViewBag.paymentId;
    var isLive = (bool)ViewBag.isLive;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1bca79aa112a3d0f656ae129cc88bca8d7a88c114687", async() => {
                WriteLiteral(@"
    <title>check out</title>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <style>
        body {
            background-color: #f6f6f5;
            padding-bottom: 0;
        }

        body, html {
            background: #fff;
            color: #fff;
            font-family: 'JF-Flat-regular';
        }

        .wpwl-control, .wpwl-group-registration {
            color: #000
        }

        .content-page .content {
            margin-top: 0;
        }

        .button {
            width: 100%
        }

        ");
                WriteLiteral(@"@media (min-width: 550px) {
            /* this rule applies only to devices with a minimum screen width of 480px */
            .button {
                width: 50%;
            }
        }

        .input,
        .button {
            height: 44px;
            width: 100%;
        }


        .topbar {
            display: none;
        }

        .side-menu {
            display: none;
        }

        .wpwl-form-card {
            border-radius: 10px;
            background-image: linear-gradient(30deg, rgb(99, 171, 109) 70%, rgba(255,255,255,0.2) 70%),linear-gradient(45deg, rgba(255,255,255,0) 75%, rgb(159, 112, 160) 75%),linear-gradient(60deg, rgb(135, 170, 65) 80%, rgb(27, 172, 192) 80%) !important;
            background-color: silver;
        }

        body.fixed-left-void, body.mobile {
            min-height: 400px;
        }

        #wrapper.enlarged .footer {
            display: none
        }

        .wpwl-button.wpwl-button-pay {
            min-width");
                WriteLiteral(@": 200px;
            color: #fff !important;
            opacity: 1;
            padding: 7px;
            border: none;
            font-size: 16px;
            background-image: linear-gradient(to right, #15acc7, #abaa17, #9e6bac ) !important;
            margin: 10px auto;
            display: block;
            font-weight: 600;
            color: #fff;
            border-radius: 9px;
            transition: all .4s ease-in-out;
            float: none;
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1bca79aa112a3d0f656ae129cc88bca8d7a88c117837", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1bca79aa112a3d0f656ae129cc88bca8d7a88c118099", async() => {
                    WriteLiteral("\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 5, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2470, "/Payments/WebSubmit?paymentId=", 2470, 30, true);
#nullable restore
#line 96 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Payments\WebPay.cshtml"
AddHtmlAttributeValue("", 2500, paymentId, 2500, 10, false);

#line default
#line hidden
#nullable disable
                AddHtmlAttributeValue("", 2510, "&userId=", 2510, 8, true);
#nullable restore
#line 96 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Payments\WebPay.cshtml"
AddHtmlAttributeValue("", 2518, userId, 2518, 7, false);

#line default
#line hidden
#nullable disable
                AddHtmlAttributeValue("", 2525, "&/", 2525, 2, true);
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>\r\n        var wpwlOptions = { style: \"card\" }\r\n    </script>\r\n\r\n");
#nullable restore
#line 102 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Payments\WebPay.cshtml"
     if (isLive)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script");
                BeginWriteAttribute("src", " src=\"", 2709, "\"", 2776, 2);
                WriteAttributeValue("", 2715, "https://oppwa.com/v1/paymentWidgets.js?checkoutId=", 2715, 50, true);
#nullable restore
#line 104 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Payments\WebPay.cshtml"
WriteAttributeValue("", 2765, checkOutId, 2765, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
#nullable restore
#line 105 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Payments\WebPay.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script");
                BeginWriteAttribute("src", " src=\"", 2828, "\"", 2900, 2);
                WriteAttributeValue("", 2834, "https://test.oppwa.com/v1/paymentWidgets.js?checkoutId=", 2834, 55, true);
#nullable restore
#line 108 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Payments\WebPay.cshtml"
WriteAttributeValue("", 2889, checkOutId, 2889, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
#nullable restore
#line 109 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Payments\WebPay.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
