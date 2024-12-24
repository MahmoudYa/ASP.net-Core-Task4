using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REAL_Estate.Components.Extensions;
using REAL_Estate.Components.Notifications;
using REAL_Estate.Components.Security;
using REAL_Estate.Resources;
using REAL_Estate.Services;

namespace REAL_Estate.Controllers;

[AllowUnauthorized]
public class Home : ServicedController<AccountService>
{
    public Home(AccountService service)
        : base(service)
    {
    }

    [HttpGet]
    public ActionResult Index()
    {
        if (!Service.IsActive(User.Id()))
            return RedirectToAction(nameof(Auth.Logout), nameof(Auth));

        return View();
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult Error()
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;

        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            Alerts.Add(new Alert
            {
                Id = "SystemError",
                Type = AlertType.Danger,
                Message = Resource.ForString("SystemError", HttpContext.TraceIdentifier)
            });

            return Json(new { alerts = Alerts });
        }

        return View();
    }

    [AllowAnonymous]
    public new ActionResult NotFound()
    {
        if (Service.IsLoggedIn(User) && !Service.IsActive(User.Id()))
            return RedirectToAction(nameof(Auth.Logout), nameof(Auth));

        Response.StatusCode = StatusCodes.Status404NotFound;

        return View();
    }
}
