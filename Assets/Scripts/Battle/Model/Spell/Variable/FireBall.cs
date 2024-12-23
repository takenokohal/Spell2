using Battle.Model.BattleObject.Bullet;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;

namespace Battle.Model.Spell.Variable
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