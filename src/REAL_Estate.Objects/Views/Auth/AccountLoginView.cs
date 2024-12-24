using REAL_Estate.Components.Mvc;

namespace REAL_Estate.Objects;

public class AccountLoginView : AView
{
    [StringLength(32)]
    public String Username { get; set; }

    [NotTrimmed]
    [StringLength(32)]
    public String Password { get; set; }

    public String? ReturnUrl { get; set; }
}
