using REAL_Estate.Components.Mvc;

namespace REAL_Estate.Objects;

public class AccountResetView : AView
{
    [StringLength(36)]
    public String? Token { get; set; }

    [NotTrimmed]
    [StringLength(32)]
    public String NewPassword { get; set; }
}
