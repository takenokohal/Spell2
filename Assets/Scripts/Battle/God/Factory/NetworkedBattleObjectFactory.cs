﻿using Battle.AssetHolders;
using Battle.Domain.BaseRules.BattleObject;
using Battle.Domain.Core.Player;
using Battle.Domain.Interfaces.Factory;
using Fusion;
using UnityEngine;
using VContainer;

namespace Battle.God.Factory
{
    //BattleObjectは生成した側だけが処理を行う（権限を持たない側は状態同期のみ行う）
    public class NetworkedBattleObjectFactory : IBattleObjectFactory
    {
        [Inject] private readonly BattleObjectAssetHolder _battleObjectAssetHolder;
        [Inject] private readonly AllPlayerManager _allPlayerManager;

        [Inject] private readonly NetworkRunner _networkRunner;

        public T Create<T>(string bulletKey, PlayerKey ownerKey, Vector2 pos, Quaternion rot = new())
            where T : BattleObjectBase
        {
            var prefab = _battleObjectAssetHolder.Find(bulletKey);
            var v = _networkRunner.Spawn(prefab, pos, rot);
            v.Construct(new BattleObjectBase.ConstructParameter(ownerKey, _allPlayerManager));
            return (T)v;
        }
    }
}