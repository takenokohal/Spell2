using Fusion;
using SpellProject.Battle.Domain.BaseRules.BattleObject;
using SpellProject.Battle.Domain.Core;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces;
using SpellProject.Battle.Domain.Interfaces.Factory;
using SpellProject.Data.AssetHolders;
using UnityEngine;
using VContainer;

namespace SpellProject.Battle.God.Factory
{
    public class NetworkedBattleObjectFactory : IBattleObjectFactory
    {
        [Inject] private readonly BattleObjectAssetHolder _battleObjectAssetHolder;
        [Inject] private readonly AllPlayerManager _allPlayerManager;

        [Inject] private readonly NetworkRunner _networkRunner;

        [Inject] private readonly IBattleModeManager _battleModeManager;

        public T Create<T>(string bulletKey, PlayerKey ownerKey, Vector2 pos, Quaternion rot = new())
            where T : BattleObjectBase
        {            
            var prefab = _battleObjectAssetHolder.FindByKey(bulletKey);

            var v = _battleModeManager.BattleMode == BattleMode.Online
                ? _networkRunner.Spawn(prefab, pos, rot)
                : Object.Instantiate(prefab, pos, rot);
            
            v.Construct(new BattleObjectBase.ConstructParameter(ownerKey, _allPlayerManager));
            return (T)v;
        }
    }
}