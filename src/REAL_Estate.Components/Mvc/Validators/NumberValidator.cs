using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using REAL_Estate.Resources;

namespace REAL_Estate.Components.Mvc;

public class NumberValidator : IClientModelValidator
{
    public void AddValidation(ClientModelValidationContext context)
    {
        if (!context.Attributes.ContainsKey("data-val-number"))
            context.Attributes["data-val-number"] = Validation.For("Number", context.ModelMetadata.GetDisplayName());
    }
}
