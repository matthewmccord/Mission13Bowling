using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Bowling.Infrastructure
{
    public class TeamTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        //public override void Process(TagHelperContext thc, TagHelperOutput tho)
        //{
        //    IUrlHelper uh = uh
        //}
    }
}
