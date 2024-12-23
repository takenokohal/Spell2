using Battle.Model.Player;

namespace Battle.Model.Attack
{
    public class AttackParameter
    {
        public PlayerKey OwnerKey { get; }

        public AttackParameter(PlayerKey ownerKey)
        {
            OwnerKey = ownerKey;
        }
    }
}