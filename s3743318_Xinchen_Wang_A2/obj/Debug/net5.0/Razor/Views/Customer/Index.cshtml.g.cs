#pragma checksum "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a86d8fce0ecf0c68cc2ad9513b8d352b09626809"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Index), @"mvc.1.0.view", @"/Views/Customer/Index.cshtml")]
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
#line 1 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\_ViewImports.cshtml"
using s3743318_Xinchen_Wang_A2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\_ViewImports.cshtml"
using s3743318_Xinchen_Wang_A2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\_ViewImports.cshtml"
using s3743318_Xinchen_Wang_A2.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a86d8fce0ecf0c68cc2ad9513b8d352b09626809", @"/Views/Customer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc4eb4c7af64cc047d40abeb096aaf224d31d2d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Customer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-secondary btn-sm m-2 col-sm-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ATM", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Statement", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SchedualBillPay", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ManageBillPay", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
  
    ViewData["Title"] = "Customer Accounts";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"display-4\">Welcome, ");
#nullable restore
#line 6 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                          Write(Model.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 7 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
 if (Model.CustomerID == 0000)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""col-md-6 mt-3"">
        <h1>Thank you for registering MCBA Internet Banking</h1>
        <p class=""mt-2 text-info"">Please be adviced:</p>
        <p class=""mt-2"">
            All account openning requires in branch opeartions.
            Please visit one of our branches around the universe
            to open an new account in order to use Online banking system.
        </p>
    </div>
");
#nullable restore
#line 18 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row mt-3\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a86d8fce0ecf0c68cc2ad9513b8d352b096268097090", async() => {
                WriteLiteral("ATM");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a86d8fce0ecf0c68cc2ad9513b8d352b096268098333", async() => {
                WriteLiteral("My Statement");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <button class=\"btn btn-outline-secondary btn-sm m-2 dropdown-toggle col-sm-2\" data-toggle=\"dropdown\">\r\n            Bill Payment\r\n        </button>\r\n        <ul class=\"dropdown-menu\">\r\n            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a86d8fce0ecf0c68cc2ad9513b8d352b096268099799", async() => {
                WriteLiteral("Schedual Bill Payment");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a86d8fce0ecf0c68cc2ad9513b8d352b0962680911073", async() => {
                WriteLiteral("Manage Bill Payment");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
        </ul>
    </div>
    <h3 class=""mt-5"">Accounts Detail</h3>
    <table class=""table table-hover text-center"">
        <thead>
            <tr>
                <th>Account Number</th>
                <th>Account Type</th>
                <th>Current Balance</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 42 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
             foreach (var account in Model.Account)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                 if (account.AccountStatus == Status.Locked)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"alert-warning\">\r\n                        <td>");
#nullable restore
#line 47 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                       Write(Html.DisplayFor(x => account.AccountNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 48 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                       Write(Html.DisplayFor(x => account.AccountType));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 49 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                       Write(Html.DisplayFor(x => account.Balance));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 51 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 55 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                       Write(Html.DisplayFor(x => account.AccountNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 56 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                       Write(Html.DisplayFor(x => account.AccountType));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 57 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                       Write(Html.DisplayFor(x => account.Balance));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 59 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 63 "E:\ASP\s3743318_Xinchen_Wang_A2\s3743318_Xinchen_Wang_A2\Views\Customer\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
