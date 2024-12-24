using REAL_Estate.Components.Tree;

namespace REAL_Estate.Objects;

public class RoleViewTests
{
    [Fact]
    public void RoleView_CreatesEmpty()
    {
        MvcTree actual = new RoleView().Permissions;

        Assert.Empty(actual.SelectedIds);
        Assert.Empty(actual.Nodes);
    }
}
