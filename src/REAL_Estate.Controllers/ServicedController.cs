using REAL_Estate.Services;

namespace REAL_Estate.Controllers;

public abstract class ServicedController<TService> : AController
    where TService : IService
{
    protected TService Service { get; }

    protected ServicedController(TService service)
    {
        Service = service;
    }

    protected override void Dispose(Boolean disposing)
    {
        Service.Dispose();

        base.Dispose(disposing);
    }
}
