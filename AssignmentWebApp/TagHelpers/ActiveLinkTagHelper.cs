using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace AssignmentWebApp.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "asp-active-link")]
    public class ActiveLinkTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var currentController = ViewContext.RouteData.Values["controller"]?.ToString();
            var currentAction = ViewContext.RouteData.Values["action"]?.ToString();

            if (string.Equals(currentController, Controller, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentAction, Action, StringComparison.OrdinalIgnoreCase))
            {
                var existingClasses = output.Attributes["class"]?.Value?.ToString() ?? "";
                output.Attributes.SetAttribute("class", $"{existingClasses} active".Trim());
            }

            output.Attributes.RemoveAll("asp-active-link");
        }
    }
}
