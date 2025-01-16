using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using REAL_Estate.Resources;

namespace REAL_Estate.Components.Mvc;

public class CompareAdapter : AttributeAdapterBase<CompareAttribute>
{
    public CompareAdapter(CompareAttribute attribute)
        : base(attribute, null)
    {
    }

    public override void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes["data-val-equalto"] = GetErrorMessage(context);
        context.Attributes["data-val-equalto-other"] = Attribute.OtherProperty;
    }
    public override String GetErrorMessage(ModelValidationContextBase validationContext)
    {
        String otherPropertyDisplayName = Resource.ForProperty(validationContext.ModelMetadata.ContainerType!, Attribute.OtherProperty);

        return Validation.For("Compare", validationContext.ModelMetadata.GetDisplayName(), otherPropertyDisplayName);
    }
}
