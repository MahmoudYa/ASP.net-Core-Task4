using REAL_Estate.Components.Mvc;

namespace REAL_Estate.Objects;

public class ProfileDeleteView : AView
{
    [NotTrimmed]
    [StringLength(32)]
    public String Password { get; set; }
}
