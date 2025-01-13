using Fusion;
using SpellProject.Battle.Detail.ConstData;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.God.Binder;
using SpellProject.Battle.God.Factory;
using SpellProject.Battle.Infrastructure;
using SpellProject.Battle.View;
using SpellProject.Battle.View.MagicCircles;
using SpellProject.Battle.View.UI;
using SpellProject.Data.AssetHolders;
using SpellProject.Data.Database;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SpellProject.Battle.God
{
    public class BattleLifetimeScope : LifetimeScope
    {
        [SerializeField] private SpellAdditionalDatabase spellAdditionalDatabase;
        [SerializeField] private BattleObjectAssetHolder battleObjectAssetHolder;
        [SerializeField] private BattleConstDataProvider battleConstDataProvider;


        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("aaa");
            builder.RegisterComponentInHierarchy<NetworkRunner>();

            //EntryPoint
            builder.RegisterComponentInHierarchy<BattleEntryPoint>();

            //Factory
            builder.Register<SpellFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<NetworkedBattleObjectFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<MagicCircleFactory>().AsImplementedInterfaces();

            //Binder
            builder.RegisterComponentInHierarchy<PlayerBinder>();

            //Manager
            builder.RegisterComponentInHierarchy<BattleModeManager>().AsImplementedInterfaces();
            builder.Register<AllPlayerManager>(Lifetime.Singleton);

            //Data
            builder.RegisterInstance(spellAdditionalDatabase).AsImplementedInterfaces();
            builder.RegisterInstance(battleConstDataProvider).AsImplementedInterfaces();

            //AssetHolder
            builder.RegisterInstance(battleObjectAssetHolder);
            
            //UI
            builder.RegisterComponentInHierarchy<PlayerLifeViewManager>();
        }
    }
}