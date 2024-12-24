using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace REAL_Estate.Components.Security;

[ExcludeFromCodeCoverage]
public class InheritedAllowAnonymousController : AllowAnonymousController
{
    [HttpGet]
    public ViewResult InheritanceAction()
    {
        return View();
    }
}
