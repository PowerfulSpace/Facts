#pragma checksum "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\Facts\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d99428374eb514d5c1ed9895856c4f2730426ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Facts_Show), @"mvc.1.0.view", @"/Views/Facts/Show.cshtml")]
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
#line 1 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\_ViewImports.cshtml"
using PowerfulSpace.Facts.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\_ViewImports.cshtml"
using PowerfulSpace.Facts.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\Facts\Show.cshtml"
using Calabonga.OperationResults;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d99428374eb514d5c1ed9895856c4f2730426ee", @"/Views/Facts/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"937978832bef71399d41d2fcf202a36ec01eba56", @"/Views/_ViewImports.cshtml")]
    public class Views_Facts_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Calabonga.OperationResults.OperationResult<PowerfulSpace.Facts.Web.ViewModels.FactViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Fact", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\Facts\Show.cshtml"
  
    ViewData["HideLink"] = true;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\Facts\Show.cshtml"
 if (!Model.Ok)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Ошибка</h1>\r\n    <p class=\"alert alert-warning\">\r\n        ");
#nullable restore
#line 13 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\Facts\Show.cshtml"
   Write(Model.Metadata.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 15 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\Facts\Show.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2d99428374eb514d5c1ed9895856c4f2730426ee4891", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 18 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\Facts\Show.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.Result;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 18 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\Facts\Show.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.ViewData = ViewData;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("view-data", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.ViewData, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 19 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\PowerfulSpace.Facts.Web\Views\Facts\Show.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Calabonga.OperationResults.OperationResult<PowerfulSpace.Facts.Web.ViewModels.FactViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591