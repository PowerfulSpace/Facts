﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Powerful.Facts.Contracts;
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

        [Inject] public IJSRuntime jsRuntime { get;set;}

        protected List<string> Founded { get; set; }

        protected string TagName { get; set; }

        [Inject ]private ITagSearchService TagSearchService { get; set; }




        protected async Task DeleteTag(string tag)
        {
            if (string.IsNullOrEmpty(tag)) { return; }

            var tagToDelete = Tags.SingleOrDefault(x => x == tag);

            if(tagToDelete is null) { return; }

            Tags.Remove(tag);

            await new RazorInterop(jsRuntime).SetTagsTotal(Tags.Count);
        }


        protected void SearchTags(ChangeEventArgs args)
        {
            if(args?.Value is null)
            {
                Founded = null;
                return;
            }

            if (string.IsNullOrEmpty(args.Value.ToString()))
            {
                Founded = null;
                return;
            }

            Founded = TagSearchService.SearchTags(args.Value.ToString());

        }



        protected async Task AddTag(string value)
        {

            var tag = value?.ToLower().Trim();

            if (string.IsNullOrEmpty(tag))
            {
                return;
            }

            Tags ??= new List<string>();

            if(!Tags.Exists( x => x.Equals(tag, StringComparison.InvariantCulture)))
            {
                Tags.Add(tag);
                await new RazorInterop(jsRuntime).SetTagsTotal(Tags.Count);
            }

            TagName = string.Empty;
            Founded = null;
        }

    }
}
