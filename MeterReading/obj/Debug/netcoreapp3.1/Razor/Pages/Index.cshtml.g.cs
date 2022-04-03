#pragma checksum "C:\Users\Sri\source\repos\EnsekTestGit\EnsekTestGit\MeterReading\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "940ea55dd2609352bfee7a684fc15842db24586b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MeterReading.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace MeterReading.Pages
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
#line 1 "C:\Users\Sri\source\repos\EnsekTestGit\EnsekTestGit\MeterReading\Pages\_ViewImports.cshtml"
using MeterReading;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"940ea55dd2609352bfee7a684fc15842db24586b", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30f405c59e6dca4b668dfbefcebc89122c396eb6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Sri\source\repos\EnsekTestGit\EnsekTestGit\MeterReading\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Upload Meter Readings</h1>\r\n    <div class=\"row\">\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "940ea55dd2609352bfee7a684fc15842db24586b3732", async() => {
                WriteLiteral("\r\n\r\n            <div class=\"input-group mb-3\">\r\n                <input type=\"file\" class=\"form-control\" id=\"fileUpload\">\r\n                <label class=\"input-group-text\" id=\"upload\">Upload</label>\r\n            </div>\r\n\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
    <div class=""row"">
        <div class=""col-md-4"">
            <div class=""form-floating"">
                <label for=""floatingTextarea"" id=""successCount"">Success Data :0</label>
                <textarea class=""form-control"" id=""successArea"" rows=""20"" disabled></textarea>

            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""form-floating"">
                <label for=""floatingTextarea"" id=""failedCount"">Failed Data :0</label>
                <textarea class=""form-control"" id=""failedArea"" rows=""20"" disabled></textarea>

            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""form-floating"">
                <label for=""floatingTextarea"" id=""invalidCount"">Invalid Data :0</label>
                <textarea class=""form-control"" id=""invalidArea"" rows=""20"" disabled></textarea>
            </div>
        </div>
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#upload').click(function () {
                var data = new FormData();

                var files = $(""#fileUpload"").get(0).files;

                // Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append(""file"", files[0]);
                    $.ajax({
                        url: ""https://localhost:44367/Meter_Reading_Uploads"",
                        type: 'POST',
                        dataType: 'json',
                        contentType: false,
                        processData: false,
                        data: data,
                        success: function (res) {
                            console.log(res);
                            $(""#successCount"").html(""Success Data :"" + res.successfulReadingsCount);
                            $(""#failedCount"").html(""Failed Data :"" + res.failedReadingsCount);

                         ");
                WriteLiteral(@"   $(""#successArea"").val(getString(res.successfulReadings));
                            $(""#failedArea"").val(getString(res.failedReadings));
                            $(""#invalidArea"").val(getInvalid(res.invalidData));
                        },
                        error: function (res) {
                            console.log(res);
                        }
                    });
                }
            });

            function getString(values) {
                listText = """";
                $.each(values, function (key, value) {
                    listText += ""Record "" + (key + 1) + "" :"" + value.accountId + "","" + value.meterReadingDate + "","" + value.meterReading + ""\n"";
                });
                return listText;
            }

            function getInvalid(values) {
                listText = """";
                i = 0;
                $.each(values, function (key, value) {
                    listText += ""Record "" + (++i) + "" :"" + value + ""\n"";
        ");
                WriteLiteral("        });\r\n                $(\"#invalidCount\").html(\"Invalid Data :\" + i);\r\n\r\n                return listText;\r\n            }\r\n        });\r\n\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591