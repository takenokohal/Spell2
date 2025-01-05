using UnityEngine;

namespace SpellProject.Battle.Domain.BaseRules.BattleObject
{
    public abstract class BulletBase : BattleObjectBase
    {
        [SerializeField] private Rigidbody2D body;

        protected Rigidbody2D Body => body;
    }
}