using UnityEngine;

namespace Battle.Model.BattleObject.Bullet
{
    public class DirectionalBullet : BulletBase
    {
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

        public void Shoot(Parameter parameter)
        {
            Body.position = parameter.Position;
            Body.linearVelocity = parameter.Velocity;
        }
    }
}