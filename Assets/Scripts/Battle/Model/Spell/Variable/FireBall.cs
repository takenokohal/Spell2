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
            var bullet = BattleObjectFactory.Create<DirectionalBullet>(GetAdditionalData<AdditionalData>().BulletKey);
            bullet.Shoot(new DirectionalBullet.Parameter(CalcPos(), CalcDir()));

            return UniTask.CompletedTask;
        }

        private Vector2 CalcPos()
        {
            return Owner.PlayerBody.Position;
        }

        private Vector2 CalcDir()
        {
            return Owner.PlayerBody.Forward;
        }
    }
}