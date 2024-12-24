using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace REAL_Estate.Components.Security;

[ExcludeFromCodeCoverage]
public class InheritedAllowUnauthorizedController : AllowUnauthorizedController
{
    [HttpGet]
    public ViewResult InheritanceAction()
    {
        return View();
    }
}
