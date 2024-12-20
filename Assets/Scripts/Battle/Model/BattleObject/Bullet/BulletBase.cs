using UnityEngine;

namespace Battle.Model.BattleObject.Bullet
{
    public abstract class BulletBase : BattleObjectBase
    {
        [SerializeField] private Rigidbody2D body;

        protected Rigidbody2D Body => body;
    }
}