using Microsoft.AspNetCore.Mvc.Rendering;

namespace REAL_Estate.Components.Mvc;

public interface ISiteMap
{
    SiteMapNode[] For(ViewContext context);
    SiteMapNode[] BreadcrumbFor(ViewContext context);
}
