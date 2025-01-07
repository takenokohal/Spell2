using SpellProject.Battle.God;
using SpellProject.Data.Database;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SpellProject.God
{
    public class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] private SpellDatabase spellDatabase;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<BattleParameterBridge>(Lifetime.Singleton);

            builder.RegisterInstance(spellDatabase);
        }
    }
}