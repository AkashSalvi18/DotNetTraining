using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AssignmentWebApp.TagHelpers
{
    [HtmlTargetElement("command-button")]
    public class CommandButtonTagHelper : TagHelper
    {
        public string Type { get; set; } = "submit";
        public string Class { get; set; } = "btn btn-primary";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("type", Type);
            output.Attributes.SetAttribute("class", Class);
            if (output.Content.IsEmptyOrWhiteSpace)
            {
                output.Content.SetContent("Submit");
            }
        }
    }
}