using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using REAL_Estate.Components.Extensions;
using REAL_Estate.Components.Security;

namespace REAL_Estate.Components.Mvc;

[HtmlTargetElement("authorize", Attributes = "action")]
public class AuthorizeTagHelper : TagHelper
{
    public String? Area { get; set; }
    public String? Action { get; set; }
    public String? Controller { get; set; }

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; }

    private IAuthorization Authorization { get; }

    public AuthorizeTagHelper(IAuthorization authorization)
    {
        Authorization = authorization;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = null;

        Int64 accountId = ViewContext!.HttpContext.User.Id();
        String? area = Area ?? ViewContext?.RouteData.Values["area"] as String;
        String? action = Action ?? ViewContext?.RouteData.Values["action"] as String;
        String? controller = Controller ?? ViewContext?.RouteData.Values["controller"] as String;

        if (!Authorization.IsGrantedFor(accountId, $"{area}/{controller}/{action}".Trim('/')))
            output.SuppressOutput();
    }
}
