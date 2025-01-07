using Fusion;
using SpellProject.Battle.Detail.ConstData;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.God.Binder;
using SpellProject.Battle.God.Factory;
using SpellProject.Battle.View;
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
        [SerializeField] private PlayerConstData playerConstData;


        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("aaa");
            builder.RegisterComponentInHierarchy<NetworkRunner>();

            //EntryPoint
            builder.RegisterComponentInHierarchy<BattleEntryPoint>();

            //Factory
            builder.Register<SpellFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BattleObjectFactory>(Lifetime.Singleton).AsImplementedInterfaces();

            //Binder
            builder.RegisterComponentInHierarchy<PlayerBinder>();

            //Manager
            builder.RegisterComponentInHierarchy<BattleModeManager>().AsImplementedInterfaces();
            builder.Register<AllPlayerManager>(Lifetime.Singleton);

            //Data
            builder.RegisterInstance(spellAdditionalDatabase).AsImplementedInterfaces();
            builder.RegisterInstance(playerConstData).AsImplementedInterfaces();

            //AssetHolder
            builder.RegisterInstance(battleObjectAssetHolder);
        }
    }
}