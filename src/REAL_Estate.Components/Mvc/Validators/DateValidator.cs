using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using REAL_Estate.Resources;

namespace REAL_Estate.Components.Mvc;

public class DateValidator : IClientModelValidator
{
    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes["data-val-date"] = Validation.For("DateTime", context.ModelMetadata.GetDisplayName());
    }
}
