using Battle.God;
using VContainer;
using VContainer.Unity;

namespace God
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<BattleParameterBridge>(Lifetime.Singleton);
        }
    }
}