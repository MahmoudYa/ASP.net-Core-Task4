using Microsoft.AspNetCore.Mvc;
using REAL_Estate.Components.Lookups;
using REAL_Estate.Components.Security;
using REAL_Estate.Data;
using REAL_Estate.Objects;
using NonFactors.Mvc.Lookup;

namespace REAL_Estate.Controllers;

[AllowUnauthorized]
public class Lookup : AController
{
    private IUnitOfWork UnitOfWork { get; }

    public Lookup(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    [HttpGet]
    public JsonResult Role(LookupFilter filter)
    {
        return Json(new MvcLookup<Role, RoleView>(UnitOfWork) { Filter = filter }.GetData());
    }

    protected override void Dispose(Boolean disposing)
    {
        UnitOfWork.Dispose();

        base.Dispose(disposing);
    }
}
