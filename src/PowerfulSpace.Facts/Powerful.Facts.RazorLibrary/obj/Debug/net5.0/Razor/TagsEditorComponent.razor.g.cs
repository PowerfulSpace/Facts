#pragma checksum "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\Powerful.Facts.RazorLibrary\TagsEditorComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee183331aa9db922a3495dc78bb4c76349e952a0"
// <auto-generated/>
#pragma warning disable 1591
namespace Powerful.Facts.RazorLibrary
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\Powerful.Facts.RazorLibrary\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
    public partial class TagsEditorComponent : TagsEditorComponentModel
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "mb-3");
            __builder.AddMarkupContent(2, "<label asp-for=\"Tags\"></label>\r\n    ");
            __builder.OpenElement(3, "div");
#nullable restore
#line 6 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\Powerful.Facts.RazorLibrary\TagsEditorComponent.razor"
         for (int i = 0; i < Tags.Count; i++)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "input");
            __builder.AddAttribute(5, "name", "Tags[" + (
#nullable restore
#line 8 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\Powerful.Facts.RazorLibrary\TagsEditorComponent.razor"
                               i

#line default
#line hidden
#nullable disable
            ) + "]");
            __builder.AddAttribute(6, "value", 
#nullable restore
#line 8 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\Powerful.Facts.RazorLibrary\TagsEditorComponent.razor"
                                           Tags[i]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 9 "D:\Git_Repositories\Projects\Facts\src\PowerfulSpace.Facts\Powerful.Facts.RazorLibrary\TagsEditorComponent.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591