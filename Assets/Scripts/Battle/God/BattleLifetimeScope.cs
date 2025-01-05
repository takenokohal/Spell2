using Battle.AssetHolders;
using Battle.Detail.ConstData;
using Battle.Detail.Input;
using Battle.Domain.Core.Player;
using Battle.God.Binder;
using Battle.God.Factory;
using Battle.View;
using Battle.View.UI;
using Data.Database;
using Fusion;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Battle.God
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
            builder.Register<NetworkedBattleObjectFactory>(Lifetime.Singleton).AsImplementedInterfaces();

            //Binder
            builder.RegisterComponentInHierarchy<PlayerBinder>();

            //Manager
            builder.RegisterComponentInHierarchy<BattleModeManager>().AsImplementedInterfaces();
            builder.Register<AllPlayerManager>(Lifetime.Singleton);

            //Data
            builder.RegisterInstance(spellAdditionalDatabase);
            builder.RegisterInstance(playerConstData).AsImplementedInterfaces();

            //AssetHolder
            builder.RegisterInstance(battleObjectAssetHolder);
        }
    }
}