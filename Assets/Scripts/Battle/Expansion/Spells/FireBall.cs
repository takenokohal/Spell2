using Battle.Domain.Core.ExpansionBaseRule.Spell;
using Battle.Expansion.BattleObjects.Bullets;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;

namespace Battle.Expansion.Spells
{
    public class FireBall : SpellBase
    {
        private class AdditionalData : ISpellAdditionalData
        {
            public readonly string BulletKey;
        }

        public override UniTask Sequence()
        {
            var bulletKey = GetAdditionalData<AdditionalData>().BulletKey;
            var bullet = BattleObjectFactory.Create<DirectionalBullet>(bulletKey, Owner.PlayerKey, CalcPos());
            bullet.Shoot(new DirectionalBullet.Parameter(CalcPos(), CalcDir()));

            return UniTask.CompletedTask;
        }

        private Vector2 CalcPos()
        {
            return Owner.PlayerBody.Position + CalcDir();
        }

        private Vector2 CalcDir()
        {
            return Owner.PlayerBody.Forward;
        }
    }
}