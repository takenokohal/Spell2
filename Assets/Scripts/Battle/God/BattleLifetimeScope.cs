using Battle.God.Factory;
using Battle.Input;
using Battle.Model.Player;
using Data.AssetHolders;
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
            builder.RegisterComponentInHierarchy<PlayerFactory>();
            builder.Register<SpellFactory>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<BattleObjectFactory>();

            //Model
            builder.Register<AllPlayerManager>(Lifetime.Singleton);

            //Input
            builder.RegisterComponentInHierarchy<BattleInputWrapper>();
            
            //Data
            builder.RegisterInstance(spellAdditionalDatabase);
            builder.RegisterInstance(playerConstData);
            
            //AssetHolder
            builder.RegisterInstance(battleObjectAssetHolder);
        }
    }
}