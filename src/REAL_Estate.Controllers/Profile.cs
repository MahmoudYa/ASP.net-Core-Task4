using Microsoft.AspNetCore.Mvc;
using REAL_Estate.Components.Extensions;
using REAL_Estate.Components.Security;
using REAL_Estate.Objects;
using REAL_Estate.Resources;
using REAL_Estate.Services;
using REAL_Estate.Validators;
using System.Security.Claims;

namespace REAL_Estate.Controllers;

[AllowUnauthorized]
public class Profile : ValidatedController<AccountValidator, AccountService>
{
    public Profile(AccountValidator validator, AccountService service)
        : base(validator, service)
    {
    }

    [HttpGet]
    public ActionResult Edit()
    {
        if (!Service.IsActive(User.Id()))
            return RedirectToAction(nameof(Auth.Logout), nameof(Auth));

        return View(Service.Get<ProfileEditView>(User.Id()));
    }

    [HttpPost]
    public ActionResult Edit(ProfileEditView profile)
    {
        profile.Id = User.Id();

        if (!Service.IsActive(profile.Id))
            return RedirectToAction(nameof(Auth.Logout), nameof(Auth));

        if (!Validator.CanEdit(profile))
            return View(profile);

        Service.Edit(profile);

        User.UpdateClaim(ClaimTypes.Name, profile.Username);
        User.UpdateClaim(ClaimTypes.Email, profile.Email.ToLower());

        Alerts.AddSuccess(Message.For<AccountView>("ProfileUpdated"), 4000);

        return RedirectToAction(nameof(Edit));
    }

    [HttpGet]
    public ActionResult Delete()
    {
        if (!Service.IsActive(User.Id()))
            return RedirectToAction(nameof(Auth.Logout), nameof(Auth));

        Alerts.AddWarning(Message.For<AccountView>("ProfileDeleteDisclaimer"));

        return View();
    }

    [HttpPost]
    [ActionName("Delete")]
    public ActionResult DeleteConfirmed(ProfileDeleteView profile)
    {
        profile.Id = User.Id();

        if (!Service.IsActive(profile.Id))
            return RedirectToAction(nameof(Auth.Logout), nameof(Auth));

        if (!Validator.CanDelete(profile))
        {
            Alerts.AddWarning(Message.For<AccountView>("ProfileDeleteDisclaimer"));

            return View(profile);
        }

        Service.Delete(profile.Id);

        Authorization.Refresh(HttpContext.RequestServices);

        return RedirectToAction(nameof(Auth.Logout), nameof(Auth));
    }
}
