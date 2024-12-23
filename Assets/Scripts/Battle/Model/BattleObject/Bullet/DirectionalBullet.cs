using Battle.Model.Attack;
using Battle.View;
using Sirenix.Serialization;
using UnityEngine;

namespace Battle.Model.BattleObject.Bullet
{
    public class DirectionalBullet : BulletBase
    {
        private IAttackView _attackView;

        public class Parameter
        {
            public Vector2 Position { get; }
            public Vector2 Velocity { get; }

            public Parameter(Vector2 position, Vector2 velocity)
            {
                Position = position;
                Velocity = velocity;
            }
        }

        protected override void InitializeOnChild()
        {
            _attackView = GetComponent<IAttackView>();
            _attackView.SetUp(new AttackParameter(OwnerKey));

            _attackView.Activate(true);
        }

        public void Shoot(Parameter parameter)
        {
            Body.position = parameter.Position;
            Body.linearVelocity = parameter.Velocity;
        }
    }
}