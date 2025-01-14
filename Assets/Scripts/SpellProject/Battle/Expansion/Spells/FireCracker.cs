using Cysharp.Threading.Tasks;
using SpellProject.Battle.Domain.BaseRules.MagicCircles;
using SpellProject.Battle.Domain.BaseRules.Spell;
using SpellProject.Battle.Expansion.BattleObjects.Bullets;
using SpellProject.Data.AssetHolders;
using UnityEngine;

namespace SpellProject.Battle.Expansion.Spells
{
    public class FireCracker : SpellBase
    {
        private class Data : ISpellAdditionalData
        {
            public BattleObjectKey BattleObjectKey;
            public int Count;
            public float BulletSpeed;
            public float Arc;
            public float Radius;
        }


        public override UniTask Sequence()
        {
            var data = GetAdditionalData<Data>();
            for (int i = 0; i < data.Count; i++)
            {
                Shoot(i).Forget();
            }

            return UniTask.CompletedTask;
        }

        private async UniTaskVoid Shoot(int i)
        {
            await MagicCircleFactory.CreateAndWait(new MagicCircleParameter(
                OwnerFacade, 1, () => CalcPos(i)));

            var bullet = BattleObjectFactory.Create<DirectionalBullet>(
                GetAdditionalData<Data>().BattleObjectKey.Key,
                OwnerKey,
                CalcPos(i));

            bullet.Shoot(
                new DirectionalBullet.Parameter(CalcPos(i), CalcDir(i) * GetAdditionalData<Data>().BulletSpeed));

            await MyDelay(3);
            BattleObjectFactory.Destroy(bullet);
        }

        private Vector2 CalcPos(int i)
        {
            var dir = CalcDir(i);
            return OwnerFacade.PlayerBody.Position + dir * GetAdditionalData<Data>().Radius;
        }

        private Vector2 CalcDir(int i)
        {
            var data = GetAdditionalData<Data>();
            var dir1 = GetDirectionOwnerToPlayer();
            var dir2 = Quaternion.Euler(0, 0, -data.Arc / 2f) * dir1;

            var currentArc = data.Arc / (data.Count - 1) * i;

            var dir3 = Quaternion.Euler(0, 0, currentArc) * dir2;
            return dir3;
        }
    }
}