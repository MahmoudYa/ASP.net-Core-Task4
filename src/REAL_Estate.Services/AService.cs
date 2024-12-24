using REAL_Estate.Data;

namespace REAL_Estate.Services;

public abstract class AService : IService
{
    protected IUnitOfWork UnitOfWork { get; }

    protected AService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public void Dispose()
    {
        UnitOfWork.Dispose();
    }
}
