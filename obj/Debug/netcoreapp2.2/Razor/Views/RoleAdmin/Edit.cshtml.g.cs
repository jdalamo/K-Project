#pragma checksum "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4453e8282a0a44f5c1364eb0d13f1934f15e185"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(fa19projectgroup16.Views.RoleAdmin.Views_RoleAdmin_Edit), @"mvc.1.0.view", @"/Views/RoleAdmin/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RoleAdmin/Edit.cshtml", typeof(fa19projectgroup16.Views.RoleAdmin.Views_RoleAdmin_Edit))]
namespace fa19projectgroup16.Views.RoleAdmin
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4453e8282a0a44f5c1364eb0d13f1934f15e185", @"/Views/RoleAdmin/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4108a5b5ca1052ae7be4e566c328ec54ad7c0d9c", @"/Views/_ViewImports.cshtml")]
    public class Views_RoleAdmin_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleEditModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
  
    ViewBag.Title = "Edit Role";

#line default
#line hidden
            BeginContext(59, 16, true);
            WriteLiteral("\n<h2>Edit Role: ");
            EndContext();
            BeginContext(76, 15, false);
#line 6 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
          Write(Model.Role.Name);

#line default
#line hidden
            EndContext();
            BeginContext(91, 7, true);
            WriteLiteral("</h2>\n\n");
            EndContext();
            BeginContext(99, 24, false);
#line 8 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
Write(Html.ValidationSummary());

#line default
#line hidden
            EndContext();
            BeginContext(123, 2, true);
            WriteLiteral("\n\n");
            EndContext();
#line 10 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(153, 40, true);
            WriteLiteral("    <input type=\"hidden\" name=\"roleName\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 193, "\"", 217, 1);
#line 12 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
WriteAttributeValue("", 201, Model.Role.Name, 201, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(218, 84, true);
            WriteLiteral(" />\n    <div class=\"panel panel-primary\">\n        <div class=\"panel-heading\">Add To ");
            EndContext();
            BeginContext(303, 15, false);
#line 14 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
                                     Write(Model.Role.Name);

#line default
#line hidden
            EndContext();
            BeginContext(318, 51, true);
            WriteLiteral("</div>\n        <table class=\"table table-striped\">\n");
            EndContext();
#line 16 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
             if (Model.NonMembers.Count() == 0)
            {

#line default
#line hidden
            BeginContext(431, 106, true);
            WriteLiteral("                <tr>\n                    <td colspan=\"3\">All Users Are Members</td>\n                </tr>\n");
            EndContext();
#line 21 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(582, 159, true);
            WriteLiteral("                <tr>\n                    <th>First Name</th>\n                    <th>Email</th>\n                    <th>Add to Role</th>\n                </tr>\n");
            EndContext();
#line 29 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
                foreach (AppUser user in Model.NonMembers)
                {

#line default
#line hidden
            BeginContext(818, 53, true);
            WriteLiteral("                    <tr>\n                        <td>");
            EndContext();
            BeginContext(872, 14, false);
#line 32 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
                       Write(user.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(886, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(921, 13, false);
#line 33 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
                       Write(user.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(934, 101, true);
            WriteLiteral("</td>\n                        <td>\n                            <input type=\"checkbox\" name=\"IdsToAdd\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1035, "\"", 1051, 1);
#line 35 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
WriteAttributeValue("", 1043, user.Id, 1043, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1052, 60, true);
            WriteLiteral(" />\n                        </td>\n                    </tr>\n");
            EndContext();
#line 38 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
                }
            }

#line default
#line hidden
            BeginContext(1144, 28, true);
            WriteLiteral("        </table>\n    </div>\n");
            EndContext();
            BeginContext(1173, 85, true);
            WriteLiteral("    <div class=\"panel panel-primary\">\n        <div class=\"panel-heading\">Remove from ");
            EndContext();
            BeginContext(1259, 15, false);
#line 44 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
                                          Write(Model.Role.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1274, 51, true);
            WriteLiteral("</div>\n        <table class=\"table table-striped\">\n");
            EndContext();
#line 46 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
             if (Model.Members.Count() == 0)
            {

#line default
#line hidden
            BeginContext(1384, 105, true);
            WriteLiteral("                <tr>\n                    <td colspan=\"3\">No Users Are Members</td>\n                </tr>\n");
            EndContext();
#line 51 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1534, 164, true);
            WriteLiteral("                <tr>\n                    <th>First Name</th>\n                    <th>Email</th>\n                    <th>Remove From Role</th>\n                </tr>\n");
            EndContext();
#line 59 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
                foreach (AppUser user in Model.Members)
                {

#line default
#line hidden
            BeginContext(1772, 53, true);
            WriteLiteral("                    <tr>\n                        <td>");
            EndContext();
            BeginContext(1826, 14, false);
#line 62 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
                       Write(user.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1840, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1875, 13, false);
#line 63 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
                       Write(user.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1888, 104, true);
            WriteLiteral("</td>\n                        <td>\n                            <input type=\"checkbox\" name=\"IdsToDelete\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1992, "\"", 2008, 1);
#line 65 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
WriteAttributeValue("", 2000, user.Id, 2000, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2009, 60, true);
            WriteLiteral(" />\n                        </td>\n                    </tr>\n");
            EndContext();
#line 68 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
                }
            }

#line default
#line hidden
            BeginContext(2101, 28, true);
            WriteLiteral("        </table>\n    </div>\n");
            EndContext();
            BeginContext(2130, 67, true);
            WriteLiteral("    <button type=\"submit\" class=\"btn btn-danger\">Save</button>\n    ");
            EndContext();
            BeginContext(2197, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4453e8282a0a44f5c1364eb0d13f1934f15e18511289", async() => {
                BeginContext(2243, 6, true);
                WriteLiteral("Cancel");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2253, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 75 "/Users/jd/Desktop/kproject/Views/RoleAdmin/Edit.cshtml"
}

#line default
#line hidden
            BeginContext(2256, 5, true);
            WriteLiteral("\n\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleEditModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
