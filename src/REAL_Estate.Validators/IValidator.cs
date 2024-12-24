using Microsoft.AspNetCore.Mvc.ModelBinding;
using REAL_Estate.Components.Notifications;

namespace REAL_Estate.Validators;

public interface IValidator : IDisposable
{
    Alerts Alerts { get; set; }
    ModelStateDictionary ModelState { get; set; }
}
