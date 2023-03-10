#pragma checksum "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c83c128483861c31683ff429ef2b7e4a3bb9ad2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OilStations_Index), @"mvc.1.0.view", @"/Views/OilStations/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c83c128483861c31683ff429ef2b7e4a3bb9ad2", @"/Views/OilStations/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7382dd3c129ccafb293208743c1af92e67834108", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_OilStations_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KhadimiEssa.Data.TableDb.OilStation>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card-box\">\r\n");
            WriteLiteral("\r\n    <h2 class=\"header-title m-t-0 m-b-30\">المحطة</h2>\r\n\r\n    <div>\r\n        <p>\r\n            ");
#nullable restore
#line 14 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
       Write(Html.ActionLink("اضافة", "Create", "OilStations", null, new { @class = "btn btn-primary btn-rounded w-md waves-effect waves-light m-b-5" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </p>
        <table id=""datatable-responsive"" class=""table table-striped table-bordered dt-responsive nowrap"" cellspacing=""0"" width=""100%"">
            <thead style=""text-align:center"">
                <tr>
                    <th>الاسم بالعربية</th>
                    <th>الاسم بالانجليزية</th>
                    <th>العنوان</th>
                    <th> الحالة </th>
                    <th>تغيير الحالة </th>
                    <th>نطاق الخدمة </th>
                    <th>تعديل </th>
                    <th>حذف </th>
                </tr>
            </thead>
            <tbody style=""text-align:center"">
");
#nullable restore
#line 30 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NameAr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NameEn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <button class=\"btn btn-primary btn-rounded\"");
            BeginWriteAttribute("id", " id=\"", 1504, "\"", 1523, 2);
            WriteAttributeValue("", 1509, "open", 1509, 4, true);
#nullable restore
#line 40 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
WriteAttributeValue("", 1513, item.Id, 1513, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1524, "\"", 1554, 3);
            WriteAttributeValue("", 1534, "showMap(\'", 1534, 9, true);
#nullable restore
#line 40 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
WriteAttributeValue("", 1543, item.Id, 1543, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1551, "\');", 1551, 3, true);
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\"#mapModal\" data-lat=\"");
#nullable restore
#line 40 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                                                                                                                                                                        Write(item.Lat);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-long=\"");
#nullable restore
#line 40 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                                                                                                                                                                                              Write(item.Lng);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">اظهار الموقع</button>\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 43 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                          
                            if (item.IsActive == true)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <label");
            BeginWriteAttribute("id", " id=\"", 1872, "\"", 1885, 1);
#nullable restore
#line 46 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
WriteAttributeValue("", 1877, item.Id, 1877, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:green;font-size: 17px;\">مفعل</label>\r\n");
#nullable restore
#line 47 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <label");
            BeginWriteAttribute("id", " id=\"", 2072, "\"", 2085, 1);
#nullable restore
#line 50 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
WriteAttributeValue("", 2077, item.Id, 2077, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"color:red;font-size: 17px;\">غير مفعل</label>\r\n");
#nullable restore
#line 51 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        <input type=\"button\" value=\"تغيير الحالة\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2316, "\"", 2348, 3);
            WriteAttributeValue("", 2326, "ChangeStatus(", 2326, 13, true);
#nullable restore
#line 55 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
WriteAttributeValue("", 2339, item.Id, 2339, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2347, ")", 2347, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-purple btn-rounded\" />\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 58 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ServiceScope));

#line default
#line hidden
#nullable disable
            WriteLiteral(" km\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 61 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                   Write(Html.ActionLink("تعديل", "Edit", new { id = item.Id }, new { @class = "btn btn-info btn-rounded" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                     <td>\r\n                        <input type=\"button\" value=\"حذف\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2808, "\"", 2834, 3);
            WriteAttributeValue("", 2818, "Delete(", 2818, 7, true);
#nullable restore
#line 64 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
WriteAttributeValue("", 2825, item.Id, 2825, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2833, ")", 2833, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-purple btn-rounded\" />\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 67 "D:\AWMER\KhadimiEssa\KhadimiEssa\Views\OilStations\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>

        <!-- -------------------------------------------------------------------------------------------------- -->
    </div><!-- end row -->
</div>




<!-- Modal Map -->
<div class=""modal fade"" id=""mapModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">الموقع</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div id=""map"" style=""height: 354px; width:100%;""> </div>

            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn-new-style"" data-dismiss=""modal"">اغلاق</butt");
            WriteLiteral("on>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"


    <script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyB_oSewQNaoaW8F2_WxAC5eFwoeaZYpOHE&callback=initMap&language=ar""></script>

    <script>

        function ChangeStatus(id) {
            $.ajax({
                url: ""/OilStations/ChangeState"",
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
                title: 'هل انت متاكد م");
                WriteLiteral(@"ن حذف هذا العنصر  ؟',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#3085d6',
                cancelButtonText: 'اغلاق',
                confirmButtonText: 'حذف',
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        url: ""/OilStations/Delete"",
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
                        failure: function (inf");
                WriteLiteral(@"o) {

                        }
                    })
                }
            })
        }




        function initMap(myLoc) {
            var marker = new google.maps.Marker({
                position: myLoc
            });
            var opt = {
                center: myLoc,
                zoom: 14,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById(""map""), opt);
            marker.setMap(map);
        };

        function showMap(id) {
            debugger;
            var lat = $('#open' + id).data('lat');
            var long = $('#open' + id).data('long');
            initMap(new google.maps.LatLng(lat, long));
        }


    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KhadimiEssa.Data.TableDb.OilStation>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
