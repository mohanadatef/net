#pragma checksum "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47288705c5f4bd8b77e3e03de8435f34f5b669e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47288705c5f4bd8b77e3e03de8435f34f5b669e9", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7382dd3c129ccafb293208743c1af92e67834108", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    #nullable disable
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\Shared\Error.cshtml"
  
    Layout = null;
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47288705c5f4bd8b77e3e03de8435f34f5b669e93418", async() => {
                WriteLiteral("\r\n    <style>\r\n        ");
                WriteLiteral(@"@import url(https://fonts.googleapis.com/css?family=opensans:500);

        body {
            background: #33cc99;
            color: #fff;
            font-family: 'Open Sans', sans-serif;
            max-height: 700px;
            overflow: hidden;
        }

        .c {
            text-align: center;
            display: block;
            position: relative;
            width: 80%;
            margin: 100px auto;
        }

        ._404 {
            font-size: 220px;
            position: relative;
            display: inline-block;
            z-index: 2;
            height: 250px;
            letter-spacing: 15px;
        }

        ._1 {
            text-align: center;
            display: block;
            position: relative;
            letter-spacing: 12px;
            font-size: 4em;
            line-height: 80%;
        }

        ._2 {
            text-align: center;
            display: block;
            position: relative;
            font-size: 20");
                WriteLiteral(@"px;
        }

        .text {
            font-size: 70px;
            text-align: center;
            position: relative;
            display: inline-block;
            margin: 19px 0px 0px 0px;
            /* top: 256.301px; */
            z-index: 3;
            width: 100%;
            line-height: 1.2em;
            display: inline-block;
        }


        .btn {
            background-color: rgb( 255, 255, 255 );
            position: relative;
            display: inline-block;
            width: 358px;
            padding: 5px;
            z-index: 5;
            font-size: 25px;
            margin: 0 auto;
            color: #33cc99;
            text-decoration: none;
            margin-right: 10px
        }

        .right {
            float: right;
            width: 60%;
        }

        hr {
            padding: 0;
            border: none;
            border-top: 5px solid #fff;
            color: #fff;
            text-align: center;
            m");
                WriteLiteral(@"argin: 0px auto;
            width: 420px;
            height: 10px;
            z-index: -10;
        }

            hr:after {
                content: ""\2022"";
                display: inline-block;
                position: relative;
                top: -0.75em;
                font-size: 2em;
                padding: 0 0.2em;
                background: #33cc99;
            }

        .cloud {
            width: 350px;
            height: 120px;
            background: #FFF;
            background: linear-gradient(top, #FFF 100%);
            background: -webkit-linear-gradient(top, #FFF 100%);
            background: -moz-linear-gradient(top, #FFF 100%);
            background: -ms-linear-gradient(top, #FFF 100%);
            background: -o-linear-gradient(top, #FFF 100%);
            border-radius: 100px;
            -webkit-border-radius: 100px;
            -moz-border-radius: 100px;
            position: absolute;
            margin: 120px auto 20px;
            z-index");
                WriteLiteral(@": -1;
            transition: ease 1s;
        }

            .cloud:after, .cloud:before {
                content: '';
                position: absolute;
                background: #FFF;
                z-index: -1
            }

            .cloud:after {
                width: 100px;
                height: 100px;
                top: -50px;
                left: 50px;
                border-radius: 100px;
                -webkit-border-radius: 100px;
                -moz-border-radius: 100px;
            }

            .cloud:before {
                width: 180px;
                height: 180px;
                top: -90px;
                right: 50px;
                border-radius: 200px;
                -webkit-border-radius: 200px;
                -moz-border-radius: 200px;
            }

        .x1 {
            top: -50px;
            left: 100px;
            -webkit-transform: scale(0.3);
            -moz-transform: scale(0.3);
            transform: scale(0.3);");
                WriteLiteral(@"
            opacity: 0.9;
            -webkit-animation: moveclouds 15s linear infinite;
            -moz-animation: moveclouds 15s linear infinite;
            -o-animation: moveclouds 15s linear infinite;
        }

        .x1_5 {
            top: -80px;
            left: 250px;
            -webkit-transform: scale(0.3);
            -moz-transform: scale(0.3);
            transform: scale(0.3);
            -webkit-animation: moveclouds 17s linear infinite;
            -moz-animation: moveclouds 17s linear infinite;
            -o-animation: moveclouds 17s linear infinite;
        }

        .x2 {
            left: 250px;
            top: 30px;
            -webkit-transform: scale(0.6);
            -moz-transform: scale(0.6);
            transform: scale(0.6);
            opacity: 0.6;
            -webkit-animation: moveclouds 25s linear infinite;
            -moz-animation: moveclouds 25s linear infinite;
            -o-animation: moveclouds 25s linear infinite;
        }

  ");
                WriteLiteral(@"      .x3 {
            left: 250px;
            bottom: -70px;
            -webkit-transform: scale(0.6);
            -moz-transform: scale(0.6);
            transform: scale(0.6);
            opacity: 0.8;
            -webkit-animation: moveclouds 25s linear infinite;
            -moz-animation: moveclouds 25s linear infinite;
            -o-animation: moveclouds 25s linear infinite;
        }

        .x4 {
            left: 470px;
            botttom: 20px;
            -webkit-transform: scale(0.75);
            -moz-transform: scale(0.75);
            transform: scale(0.75);
            opacity: 0.75;
            -webkit-animation: moveclouds 18s linear infinite;
            -moz-animation: moveclouds 18s linear infinite;
            -o-animation: moveclouds 18s linear infinite;
        }

        .x5 {
            left: 200px;
            top: 300px;
            -webkit-transform: scale(0.5);
            -moz-transform: scale(0.5);
            transform: scale(0.5);
       ");
                WriteLiteral("     opacity: 0.8;\r\n            -webkit-animation: moveclouds 20s linear infinite;\r\n            -moz-animation: moveclouds 20s linear infinite;\r\n            -o-animation: moveclouds 20s linear infinite;\r\n        }\r\n\r\n        ");
                WriteLiteral("@-webkit-keyframes moveclouds {\r\n            0% {\r\n                margin-left: 1000px;\r\n            }\r\n\r\n            100% {\r\n                margin-left: -1000px;\r\n            }\r\n        }\r\n\r\n        ");
                WriteLiteral("@-moz-keyframes moveclouds {\r\n            0% {\r\n                margin-left: 1000px;\r\n            }\r\n\r\n            100% {\r\n                margin-left: -1000px;\r\n            }\r\n        }\r\n\r\n        ");
                WriteLiteral("@-o-keyframes moveclouds {\r\n            0% {\r\n                margin-left: 1000px;\r\n            }\r\n\r\n            100% {\r\n                margin-left: -1000px;\r\n            }\r\n        }\r\n    </style>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47288705c5f4bd8b77e3e03de8435f34f5b669e911805", async() => {
                WriteLiteral(@"
    <div id=""clouds"">
        <div class=""cloud x1""></div>
        <div class=""cloud x1_5""></div>
        <div class=""cloud x2""></div>
        <div class=""cloud x3""></div>
        <div class=""cloud x4""></div>
        <div class=""cloud x5""></div>
    </div>
    <div class='c'>
        <div class='_404'>404</div>
        <hr>
        <div class='_1'>THE PAGE</div>
        <div class='_2'>WAS NOT FOUND</div>
        <a class='btn' href='/'>BACK TO MARS</a>
    </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591