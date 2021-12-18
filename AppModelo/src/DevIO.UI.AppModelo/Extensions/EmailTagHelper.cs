using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DevIO.UI.AppModelo.Extensions
{
    public class EmailTagHelper : TagHelper
    {
        public string EmailDomain { get; set; } = "castro.luik";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + "outlook.com";
            output.Attributes.SetAttribute("href", target);
            output.Content.SetContent(target);
        }
    }
}
