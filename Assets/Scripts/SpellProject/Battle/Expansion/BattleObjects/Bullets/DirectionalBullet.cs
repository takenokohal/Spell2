using SpellProject.Battle.Controller;
using SpellProject.Battle.Domain.BaseRules.BattleObject;
using SpellProject.Battle.Domain.Core.Attack;
using SpellProject.Battle.View;
using UnityEngine;

namespace SpellProject.Battle.Expansion.BattleObjects.Bullets
{
    public class DirectionalBullet : BulletBase
    {
        [SerializeField] private AttackActiveController attackActiveController;
        
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
            attackActiveController.SetUp(new AttackParameter(OwnerKey,10));

            attackActiveController.Activate(true);
        }

        public void Shoot(Parameter parameter)
        {
            Body.position = parameter.Position;
            Body.linearVelocity = parameter.Velocity;
        }
    }
}