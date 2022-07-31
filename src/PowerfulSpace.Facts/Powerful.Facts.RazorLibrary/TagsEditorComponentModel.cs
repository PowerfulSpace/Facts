using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerful.Facts.RazorLibrary
{
    public class TagsEditorComponentModel : ComponentBase
    {
        [Parameter]
        public List<string> Tags { get; set; }
    }
}
