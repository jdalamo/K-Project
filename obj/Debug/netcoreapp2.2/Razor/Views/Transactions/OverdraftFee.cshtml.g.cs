#pragma checksum "/Users/jd/Desktop/kproject/Views/Transactions/OverdraftFee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "684debc980b518dfb330b3fcbbdabaa0f982874e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(fa19projectgroup16.Views.Transactions.Views_Transactions_OverdraftFee), @"mvc.1.0.view", @"/Views/Transactions/OverdraftFee.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Transactions/OverdraftFee.cshtml", typeof(fa19projectgroup16.Views.Transactions.Views_Transactions_OverdraftFee))]
namespace fa19projectgroup16.Views.Transactions
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"684debc980b518dfb330b3fcbbdabaa0f982874e", @"/Views/Transactions/OverdraftFee.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4108a5b5ca1052ae7be4e566c328ec54ad7c0d9c", @"/Views/_ViewImports.cshtml")]
    public class Views_Transactions_OverdraftFee : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<fa19projectgroup16.Transaction>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "/Users/jd/Desktop/kproject/Views/Transactions/OverdraftFee.cshtml"
  
    ViewData["Title"] = "OverdraftFee";

#line default
#line hidden
            BeginContext(84, 167, true);
            WriteLiteral("\n<h1>Overdraft Fee Confirmation</h1>\n<p>Congrats! You have overdrafted this account. It will go through, don\'t worry. However, there will be a $30 fee charged. </p>\n\n\n");
            EndContext();
            BeginContext(252, 57, false);
#line 11 "/Users/jd/Desktop/kproject/Views/Transactions/OverdraftFee.cshtml"
Write(Html.ActionLink("Back to Home Page", "Index", "Accounts"));

#line default
#line hidden
            EndContext();
            BeginContext(309, 4, true);
            WriteLiteral("\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<fa19projectgroup16.Transaction> Html { get; private set; }
    }
}
#pragma warning restore 1591