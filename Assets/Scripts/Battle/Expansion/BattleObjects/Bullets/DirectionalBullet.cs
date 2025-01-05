using Battle.Domain.Core.Attack;
using Battle.Domain.Core.ExpansionBaseRule.BattleObject;
using Battle.Domain.Interfaces.Attack;
using Battle.View;
using UnityEngine;

namespace Battle.Expansion.BattleObjects.Bullets
{
    public class DirectionalBullet : BulletBase
    {
        [SerializeField] private AttackActiveView attackActiveView;
        
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
            attackActiveView.SetUp(new AttackParameter(OwnerKey,10));

            attackActiveView.Activate(true);
        }

        public void Shoot(Parameter parameter)
        {
            Body.position = parameter.Position;
            Body.linearVelocity = parameter.Velocity;
        }
    }
}