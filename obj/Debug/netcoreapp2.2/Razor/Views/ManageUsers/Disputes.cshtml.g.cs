#pragma checksum "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f6b20fef39e98b6741ebf8ae8259320172642bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(fa19projectgroup16.Views.ManageUsers.Views_ManageUsers_Disputes), @"mvc.1.0.view", @"/Views/ManageUsers/Disputes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ManageUsers/Disputes.cshtml", typeof(fa19projectgroup16.Views.ManageUsers.Views_ManageUsers_Disputes))]
namespace fa19projectgroup16.Views.ManageUsers
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f6b20fef39e98b6741ebf8ae8259320172642bc", @"/Views/ManageUsers/Disputes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4108a5b5ca1052ae7be4e566c328ec54ad7c0d9c", @"/Views/_ViewImports.cshtml")]
    public class Views_ManageUsers_Disputes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<fa19projectgroup16.Dispute>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AllDisputes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ResolveDispute", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(86, 25, true);
            WriteLiteral("\n<h1>Index</h1>\n\n<p>\n    ");
            EndContext();
            BeginContext(111, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f6b20fef39e98b6741ebf8ae8259320172642bc3981", async() => {
                BeginContext(139, 17, true);
                WriteLiteral("View All Disputes");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(160, 86, true);
            WriteLiteral("\n</p>\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
            EndContext();
            BeginContext(247, 73, false);
#line 16 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
           Write(Html.DisplayNameFor(model => model.Transaction.Account.AppUser.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(320, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(373, 72, false);
#line 19 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
           Write(Html.DisplayNameFor(model => model.Transaction.Account.AppUser.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(445, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(498, 51, false);
#line 22 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
           Write(Html.DisplayNameFor(model => model.CustomerComment));

#line default
#line hidden
            EndContext();
            BeginContext(549, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(602, 54, false);
#line 25 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
           Write(Html.DisplayNameFor(model => model.Transaction.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(656, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(709, 49, false);
#line 28 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
           Write(Html.DisplayNameFor(model => model.CorrectAmount));

#line default
#line hidden
            EndContext();
            BeginContext(758, 80, true);
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
            EndContext();
#line 34 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
 foreach (Dispute item in @ViewBag.CurrentDisputes) {

#line default
#line hidden
            BeginContext(892, 46, true);
            WriteLiteral("        <tr>\n            <td>\n                ");
            EndContext();
            BeginContext(939, 72, false);
#line 37 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Transaction.Account.AppUser.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(1011, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1064, 71, false);
#line 40 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Transaction.Account.AppUser.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(1135, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1188, 50, false);
#line 43 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
           Write(Html.DisplayFor(modelItem => item.CustomerComment));

#line default
#line hidden
            EndContext();
            BeginContext(1238, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1291, 53, false);
#line 46 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
           Write(Html.DisplayFor(modelItem => item.Transaction.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(1344, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1397, 48, false);
#line 49 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
           Write(Html.DisplayFor(modelItem => item.CorrectAmount));

#line default
#line hidden
            EndContext();
            BeginContext(1445, 52, true);
            WriteLiteral("\n            </td>\n            <td>\n                ");
            EndContext();
            BeginContext(1497, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f6b20fef39e98b6741ebf8ae8259320172642bc9764", async() => {
                BeginContext(1559, 7, true);
                WriteLiteral("Resolve");
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
#line 52 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
                                                 WriteLiteral(item.DisputeID);

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
            BeginContext(1570, 33, true);
            WriteLiteral("\n            </td>\n        </tr>\n");
            EndContext();
#line 55 "/Users/jd/Desktop/kproject/Views/ManageUsers/Disputes.cshtml"
}

#line default
#line hidden
            BeginContext(1605, 22, true);
            WriteLiteral("    </tbody>\n</table>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<fa19projectgroup16.Dispute>> Html { get; private set; }
    }
}
#pragma warning restore 1591
