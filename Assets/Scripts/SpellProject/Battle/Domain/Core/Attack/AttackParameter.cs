using SpellProject.Battle.Domain.Core.Player;

namespace SpellProject.Battle.Domain.Core.Attack
{
    public class AttackParameter
    {
        public PlayerKey OwnerKey { get; }
        public float AttackPower { get; }

        public AttackParameter(PlayerKey ownerKey, float attackPower)
        {
            OwnerKey = ownerKey;
            AttackPower = attackPower;
        }
    }
}