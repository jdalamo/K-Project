#pragma checksum "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87e91e731bd13c9f91be881d9adac95d4c93cd73"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(fa19projectgroup16.Views.StockPortfolios.Views_StockPortfolios_SellConfirm), @"mvc.1.0.view", @"/Views/StockPortfolios/SellConfirm.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/StockPortfolios/SellConfirm.cshtml", typeof(fa19projectgroup16.Views.StockPortfolios.Views_StockPortfolios_SellConfirm))]
namespace fa19projectgroup16.Views.StockPortfolios
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 3 "/Users/jd/Desktop/kproject/Views/_ViewImports.cshtml"
using fa19projectgroup16.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87e91e731bd13c9f91be881d9adac95d4c93cd73", @"/Views/StockPortfolios/SellConfirm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4108a5b5ca1052ae7be4e566c328ec54ad7c0d9c", @"/Views/_ViewImports.cshtml")]
    public class Views_StockPortfolios_SellConfirm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SellConfirm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 501, true);
            WriteLiteral(@"<h3>Summary</h3>

<table width=""800"">
    <thead>
        <tr>
            <th>
                Company
            </th>
            <th>
                Number of shares being sold
            </th>
            <th>
                Number of shares remaining after sale
            </th>
            <th>
                Related Fees
            </th>
            <th>
                Net Profit
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                ");
            EndContext();
            BeginContext(502, 15, false);
#line 26 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
           Write(ViewBag.Company);

#line default
#line hidden
            EndContext();
            BeginContext(517, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(570, 23, false);
#line 29 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
           Write(ViewBag.NumSharesWanted);

#line default
#line hidden
            EndContext();
            BeginContext(593, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(646, 23, false);
#line 32 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
           Write(ViewBag.SharesRemaining);

#line default
#line hidden
            EndContext();
            BeginContext(669, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(722, 11, false);
#line 35 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
           Write(ViewBag.Fee);

#line default
#line hidden
            EndContext();
            BeginContext(733, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(786, 17, false);
#line 38 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
           Write(ViewBag.NetProfit);

#line default
#line hidden
            EndContext();
            BeginContext(803, 83, true);
            WriteLiteral("\n            </td>\n        </tr>\n    </tbody>\n</table>\n\n<div class=\"col-md-4\">\n    ");
            EndContext();
            BeginContext(886, 794, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87e91e731bd13c9f91be881d9adac95d4c93cd736388", async() => {
                BeginContext(917, 83, true);
                WriteLiteral("\n        <div class=\"form-group\">\n            <input type=\"hidden\" name=\"numShares\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1000, "\"", 1032, 1);
#line 47 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
WriteAttributeValue("", 1008, ViewBag.NumSharesWanted, 1008, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1033, 98, true);
                WriteLiteral("/>\n        </div>\n        <div class=\"form-group\">\n            <input type=\"hidden\" name=\"stockID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1131, "\"", 1155, 1);
#line 50 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
WriteAttributeValue("", 1139, ViewBag.StockID, 1139, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1156, 95, true);
                WriteLiteral("/>\n        </div>\n        <div class=\"form-group\">\n            <input type=\"hidden\" name=\"date\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1251, "\"", 1272, 1);
#line 53 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
WriteAttributeValue("", 1259, ViewBag.Date, 1259, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1273, 99, true);
                WriteLiteral("/>\n        </div>\n        <div class=\"form-group\">\n            <input type=\"hidden\" name=\"purPrice\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1372, "\"", 1402, 1);
#line 56 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
WriteAttributeValue("", 1380, ViewBag.PurchasePrice, 1380, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1403, 221, true);
                WriteLiteral("/>\n        </div>\n        <div class=\"form-group\">\n            <input type=\"submit\" value=\"Confirm\" class=\"btn btn-primary\" />\n        </div>\n        <div class=\"form-group\">\n            <input type=\"hidden\" name=\"profit\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1624, "\"", 1650, 1);
#line 62 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
WriteAttributeValue("", 1632, ViewBag.NetProfit, 1632, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1651, 22, true);
                WriteLiteral("/>\n        </div>\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1680, 9, true);
            WriteLiteral("\n</div>\n\n");
            EndContext();
            BeginContext(1689, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87e91e731bd13c9f91be881d9adac95d4c93cd7310700", async() => {
                BeginContext(1747, 6, true);
                WriteLiteral("Cancel");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 67 "/Users/jd/Desktop/kproject/Views/StockPortfolios/SellConfirm.cshtml"
                          WriteLiteral(ViewBag.AccountID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
