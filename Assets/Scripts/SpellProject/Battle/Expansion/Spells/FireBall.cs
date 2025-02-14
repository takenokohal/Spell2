﻿using Cysharp.Threading.Tasks;
using SpellProject.Battle.Domain.BaseRules.Spell;
using SpellProject.Battle.Expansion.BattleObjects.Bullets;
using SpellProject.Data.AssetHolders;
using UnityEngine;

namespace SpellProject.Battle.Expansion.Spells
{
    public class FireBall : SpellBase
    {
        private class AdditionalData : ISpellAdditionalData
        {
            public readonly BattleObjectKey BattleObjectKey;
        }

        public override UniTask Sequence()
        {
            var bulletKey = GetAdditionalData<AdditionalData>().BattleObjectKey.Key;
            var bullet = BattleObjectFactory.Create<DirectionalBullet>(bulletKey, OwnerFacade.PlayerKey, CalcPos());
            bullet.Shoot(new DirectionalBullet.Parameter(CalcPos(), CalcDir()));

            return UniTask.CompletedTask;
        }

        private Vector2 CalcPos()
        {
            return OwnerFacade.PlayerBody.Position + CalcDir();
        }

        private Vector2 CalcDir()
        {
            return OwnerFacade.PlayerBody.Forward;
        }
    }
}