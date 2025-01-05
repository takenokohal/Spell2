using SpellProject.Battle.AssetHolders;
using SpellProject.Battle.Domain.BaseRules.BattleObject;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Factory;
using UnityEngine;
using VContainer;

namespace SpellProject.Battle.God.Factory
{
    public class BattleObjectFactory : IBattleObjectFactory
    {
        [Inject] private readonly BattleObjectAssetHolder _battleObjectAssetHolder;
        [Inject] private readonly AllPlayerManager _allPlayerManager;


        public T Create<T>(string bulletKey, PlayerKey ownerKey, Vector2 pos, Quaternion rot = new())
            where T : BattleObjectBase
        {
            var prefab = _battleObjectAssetHolder.Find(bulletKey);
            var v = Object.Instantiate(prefab, pos, rot);
            v.Construct(new BattleObjectBase.ConstructParameter(ownerKey, _allPlayerManager));
            return (T)v;
        }
    }
}